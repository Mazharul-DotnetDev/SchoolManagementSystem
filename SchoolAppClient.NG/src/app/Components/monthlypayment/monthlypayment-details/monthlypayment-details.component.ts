import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MonthlyPaymentService } from '../../../Services/monthly-payment.service';

@Component({
  selector: 'app-monthlypayment-details',
  templateUrl: './monthlypayment-details.component.html',
  styleUrl: './monthlypayment-details.component.css'
})
export class MonthlypaymentDetailsComponent implements OnInit {

  monthlyPaymentId!: number;
  monthlyPayment: any;

  constructor(
    private route: ActivatedRoute,
    private monthlyPaymentService: MonthlyPaymentService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.monthlyPaymentId = +params['id'];
      this.getMonthlypaymentDetails();
    });
  }

  getMonthlypaymentDetails() {
    this.monthlyPaymentService.getMonthlyPaymentById(this.monthlyPaymentId).subscribe(
      (data) => {
        this.monthlyPayment = data;
        console.log(this.monthlyPayment);
      },
      (error) => {
        console.error('Error fetching monthly payment details:', error);
      }
    );
  }
  printDetails(): void {
    window.print();
  }
}
