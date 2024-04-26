import { Component, OnInit } from '@angular/core';
import { CommonServices } from '../../../Services/common.service';
import { Standard } from '../../../Models/standard';
import { Student } from '../../../Models/student';
import { MonthlyPayment } from '../../../Models/monthly-payment';
import { OthersPayment } from '../../../Models/other-payment';
import { DueBalance } from '../../../Models/due-balance';

@Component({
  selector: 'app-payment-details-per-student',
  templateUrl: './payment-details-per-student.component.html',
  styleUrl: './payment-details-per-student.component.css'
})
export class PaymentDetailsPerStudentComponent implements OnInit {
  payments: MonthlyPayment[] = [];
  otherPayment: OthersPayment[] = [];
  dueBalance!: DueBalance;
  studentId!: number;
  public students: Student[] = [];
  public standards: Standard[] = [];
  filteredStudents: Student[] = [];
  public selectedStandardId: string = '';
  paymentDetails: any[] = [];


  constructor(private commonService: CommonServices) { }

  ngOnInit(): void {
    // Fetch the standards and students data when the component initializes
    this.fetchStandards();
    this.fetchStudents();
  }

  onSubmit(): void {
    // Perform any action on form submission, such as fetching payments
    this.getPaymentsByStudentId();
    this.getOtherPaymentByStudentId();
    this.geDueBalanceByStudentId();
    this.getfeePaymentByStudentId();
  }

  onStandardChange(): void {
    // Filter students based on the selected standard
    if (this.selectedStandardId) {
      this.filteredStudents = this.students.filter(student => student.standardId === parseInt(this.selectedStandardId));
    } else {
      // If no standard is selected, show all students
      this.filteredStudents = this.students;
    }
  }

  fetchStandards(): void {
    this.commonService.getAllStandards().subscribe({
      next: (data: Standard[]) => {
        this.standards = data;
      },
      error: (error) => {
        console.error('Error occurred while fetching standards:', error);
      }
    });
  }

  fetchStudents(): void {
    this.commonService.getAllStudents().subscribe({
      next: (data: Student[]) => {
        this.students = data;
        this.filteredStudents = data; // Initially, show all students
      },
      error: (error) => {
        console.error('Error occurred while fetching students:', error);
      }
    });
  }


  getPaymentsByStudentId(): void {
    if (this.studentId) {
      this.commonService.getAllPaymentsByStudentId(this.studentId)
        .subscribe(payments => this.payments = payments);
    } else {
      console.error("Student ID is not set.");
    }
  }

  getOtherPaymentByStudentId(): void {
    if (this.studentId) {
      this.commonService.getAllOtherPaymentsByStudentId(this.studentId)
        .subscribe(otherpayments => this.otherPayment = otherpayments);
    } else {
      console.error("Student ID is not set.");
    }


  }

  geDueBalanceByStudentId(): void {
    if (this.studentId) {
      this.commonService.getDueBalance(this.studentId)
        .subscribe(dueBalance => this.dueBalance = dueBalance);
    } else {
      console.error("Student ID is not set.");
    }


  }

  getfeePaymentByStudentId(): void {
    if (this.studentId) {
      this.commonService.getfeePaymentDetailsByStudentId(this.studentId)
        .subscribe(paymentDetails => this.paymentDetails = paymentDetails);
    } else {
      console.error("Student ID is not set.");
    }


  }


}
