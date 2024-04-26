import { Component, OnInit, ViewChild } from '@angular/core';
import { PageSettingsModel, FilterSettingsModel, SearchSettingsModel } from '@syncfusion/ej2-angular-grids';
import { OthersPayment } from '../../../Models/other-payment';
import { OtherPaymentService } from '../../../Services/other-payment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-other-payment-list',
  templateUrl: './other-payment-list.component.html',
  styleUrl: './other-payment-list.component.css'
})
export class OtherpaymentListComponent implements OnInit {
  @ViewChild('grid') grid: any;

  otherPayments: OthersPayment[] = [];
  confirmationDialogVisible: boolean = false;
  otherPaymentIdToDelete: number | undefined;
  searchName: string = '';

  pageSettings: PageSettingsModel = { pageSize: 5 };
  filterSettings: FilterSettingsModel = { type: 'Menu' };
  searchSettings: SearchSettingsModel = {
    fields: ['student.studentName'],
    operator: 'contains',
    ignoreCase: true
  };

  constructor(private otherPaymentService: OtherPaymentService, private router: Router) { }

  ngOnInit(): void {
    this.loadOtherPayments();
  }

  loadOtherPayments(): void {
    this.otherPaymentService.getOtherPayments().subscribe(otherPayments => {
      this.otherPayments = otherPayments;
    });
  }

  confirmDelete(id: number): void {
    this.confirmationDialogVisible = true;
    this.otherPaymentIdToDelete = id;
  }

  deleteOtherPayment(): void {
    if (this.otherPaymentIdToDelete !== undefined) {
      this.otherPaymentService.deleteOthersPayment(this.otherPaymentIdToDelete).subscribe(() => {
        this.otherPayments = this.otherPayments.filter(payment => payment.othersPaymentId !== this.otherPaymentIdToDelete);
        this.closeConfirmationDialog();
      });
    }
  }

  closeConfirmationDialog(): void {
    this.confirmationDialogVisible = false;
    this.otherPaymentIdToDelete = undefined;
  }

  customNameFilter(args: any): void {
    const filterValue = this.searchName.toLowerCase();
    args.dataSource = this.otherPayments.filter(payment => payment.student.studentName.toLowerCase().includes(filterValue));
  }

  customNameSearch(): void {
    this.grid.search(this.searchName);
  }
}
