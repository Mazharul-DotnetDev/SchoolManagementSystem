import { Component, OnInit, ViewChild } from '@angular/core';
import { MonthlyPayment } from '../../../Models/monthly-payment';
import { MonthlyPaymentService } from '../../../Services/monthly-payment.service';
import { Router } from '@angular/router';
import { PageSettingsModel, FilterSettingsModel, SearchSettingsModel } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-monthlypayment-list',
  templateUrl: './monthlypayment-list.component.html',
  styleUrl: './monthlypayment-list.component.css'
})
export class MonthlypaymentListComponent implements OnInit {
  @ViewChild('grid') grid: any;

  monthlyPayments: MonthlyPayment[] = [];
  confirmationDialogVisible: boolean = false;
  monthlyPaymentIdToDelete: number | undefined;

  searchPaymentId: string = '';

  pageSettings: PageSettingsModel = { pageSize: 5 };
  filterSettings: FilterSettingsModel = { type: 'Menu' };
  searchSettings: SearchSettingsModel = {
    fields: ['student.studentName', 'monthlyPaymentId', 'student.enrollmentNo'],
    operator: 'contains',
    ignoreCase: true
  };

  constructor(private monthlyPaymentService: MonthlyPaymentService, private router: Router) { }

  ngOnInit(): void {
    this.loadMonthlyPayments();
  }

  loadMonthlyPayments(): void {
    this.monthlyPaymentService.getAllMonthlyPayments().subscribe(monthlyPayments => {
      this.monthlyPayments = monthlyPayments;
    });
  }

  confirmDelete(id: number): void {
    this.confirmationDialogVisible = true;
    this.monthlyPaymentIdToDelete = id;
  }

  deleteMonthlyPayment(): void {
    if (this.monthlyPaymentIdToDelete !== undefined) {
      this.monthlyPaymentService.deleteMonthlyPayment(this.monthlyPaymentIdToDelete).subscribe(() => {
        this.monthlyPayments = this.monthlyPayments.filter(payment => payment.monthlyPaymentId !== this.monthlyPaymentIdToDelete);
        this.closeConfirmationDialog();
      });
    }
  }

  closeConfirmationDialog(): void {
    this.confirmationDialogVisible = false;
    this.monthlyPaymentIdToDelete = undefined;
  }

  customPaymentIdFilter(args: any): void {
    const filterValue = this.searchPaymentId.toLowerCase();
    args.dataSource = this.monthlyPayments.filter(mp => mp.monthlyPaymentId.toString().toLowerCase().includes(filterValue));
  }

  customPaymentIdSearch(): void {
    this.grid.search(this.searchPaymentId);
  }
}
