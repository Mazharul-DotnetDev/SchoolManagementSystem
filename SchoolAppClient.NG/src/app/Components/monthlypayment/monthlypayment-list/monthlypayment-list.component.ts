import { Component, OnInit } from '@angular/core';
import { MonthlyPayment } from '../../../Models/monthly-payment';
import { MonthlyPaymentService } from '../../../Services/monthly-payment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-monthlypayment-list',
  templateUrl: './monthlypayment-list.component.html',
  styleUrl: './monthlypayment-list.component.css'
})
export class MonthlypaymentListComponent implements OnInit {
  monthlyPayments: MonthlyPayment[] = [];
  searchName: string = '';

  constructor(private monthlyPaymentService: MonthlyPaymentService, private router: Router) { }

  ngOnInit(): void {
    this.loadMonthlyPayments();
  }

  loadMonthlyPayments(): void {
    this.monthlyPaymentService.getAllMonthlyPayments().subscribe(monthlyPayments => {
      this.monthlyPayments = monthlyPayments;
    });
  }
  get filteredPayments() {
    return this.monthlyPayments.filter(payment => payment.student.studentName.toLowerCase().includes(this.searchName.toLowerCase()));
  }
  deleteMonthlyPayment(id: number): void {
    this.monthlyPaymentService.deleteMonthlyPayment(id).subscribe(() => {
      // Remove the deleted monthly payment from the local array
      this.monthlyPayments = this.monthlyPayments.filter(mp => mp.monthlyPaymentId !== id);
      console.log(`Monthly payment with ID ${id} deleted successfully.`);
    }, error => {
      console.error(`Error deleting monthly payment with ID ${id}: ${error}`);
    });
  }
}
