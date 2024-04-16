import { Component, OnInit } from '@angular/core';
import { MonthlyPayment } from '../../../Models/monthly-payment';
import { Student } from '../../../Models/student';
import { Standard } from '../../../Models/standard';
import { Fee } from '../../../Models/fee';
import { AcademicMonth } from '../../../Models/academicmonth';
import { CommonServices } from '../../../Services/common.service';
import { MonthlyPaymentService } from '../../../Services/monthly-payment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-monthlypayment-create',
  templateUrl: './monthlypayment-create.component.html',
  styleUrl: './monthlypayment-create.component.css'
})
export class MonthlypaymentCreatComponent implements OnInit {

  public model: MonthlyPayment = new MonthlyPayment();
  public students: Student[] = [];
  public standards: Standard[] = [];
  public fee: Fee[] = [];
  public academicMonthList: AcademicMonth[] = [];
  public selectedStandardId: string = '';
  public totalAmount: number = 0; // Initialize totalAmount property

  constructor(
    private commonService: CommonServices,
    private monthlyPaymentService: MonthlyPaymentService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.model = new MonthlyPayment();
    this.fetchFees();
    this.fetchAcademicMonths();
    this.fetchStandards();
    this.fetchStudents();

  }

  //calculateTotalAmount(): number {
  //  let totalAmount = 0;
  //  const waver = this.model.waver || 0; // Ensure waver is defined, default to 0 if not provided

  //  for (const fee of this.filteredData.fees) {
  //    totalAmount += fee.amount * this.model.academicMonths.length - (fee.amount * this.model.academicMonths.length * waver / 100);
  //  }
  //  return totalAmount;
  //}




  calculateTotalAmount(): number {
    let totalAmount = 0;
    const waver = this.model.waver || 0; // Assuming waver is a property of the model
    const dueBalance = parseFloat((<HTMLInputElement>document.getElementById('dueBalance')).value) || 0; // Get due balance from the input field

    for (const fee of this.filteredData.fees) {
      totalAmount += (fee.amount * this.model.academicMonths.length) - (fee.amount * this.model.academicMonths.length * waver / 100) + dueBalance;
    }

    return totalAmount;
  }


  fetchFees(): void {
    this.commonService.getAllFees().subscribe({
      next: (data: Fee[]) => {
        this.fee = data;
      },
      error: (error) => {
        console.error('Error occurred while fetching fees:', error);
      }
    });
  }

  onSubmit(): void {

    this.monthlyPaymentService.createMonthlyPayment(this.model).subscribe({
      next: (createdPayment) => {
        // Assuming createdPayment contains the details of the newly created monthly payment
        this.router.navigate(['/monthlypayment', createdPayment.monthlyPaymentId, 'details']);
      },
      error: (err) => {
        console.error('Error occurred while adding payment:', err);
      }
    });
  }



  fetchAcademicMonths(): void {
    this.commonService.getAllAcademicMonths().subscribe({
      next: (data: AcademicMonth[]) => {
        this.academicMonthList = data;
      },
      error: (error) => {
        console.error('Error occurred while fetching academic months:', error);
      }
    });
  }

  fetchStudents(): void {
    this.commonService.getAllStudents().subscribe({
      next: (data: Student[]) => {
        this.students = data;
      },
      error: (error) => {
        console.error('Error occurred while fetching students:', error);
      }
    });
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

  get filteredData(): { students: Student[], fees: Fee[] } {
    if (!this.selectedStandardId.trim()) {
      return { students: this.students, fees: this.fee }; // Return all students and fees if no standard is selected
    }

    const filteredStudents = this.students.filter(student => student.standardId.toString() === this.selectedStandardId);
    const filteredFees = this.fee.filter(fee => fee.standardId.toString() === this.selectedStandardId && fee.paymentFrequency === 'Monthly');

    return { students: filteredStudents, fees: filteredFees };
  }



  //get filteredData(): { students: Student[], fees: Fee[] } {
  //  if (!this.selectedStandardId.trim()) {
  //    return { students: this.students, fees: this.fee }; // Return all students and fees if no standard is selected
  //  }

  //  const filteredStudents = this.students.filter(student => student.standardId.toString() === this.selectedStandardId);
  //  const filteredFees = this.fee.filter(fee => fee.standardId.toString() === this.selectedStandardId);

  //  return { students: filteredStudents, fees: filteredFees };
  //}

  fetchDueBalance(studentId: number): void {
    this.commonService.getDueBalance(studentId)
      .subscribe((data: any) => {
        // Update the value of the input field directly
        const dueBalanceInput = document.getElementById('dueBalance') as HTMLInputElement;
        if (dueBalanceInput) {
          dueBalanceInput.value = data.dueBalanceAmount;
        }
      }, (error) => {
        console.error('Error fetching due balance:', error);
      });
  }

}
