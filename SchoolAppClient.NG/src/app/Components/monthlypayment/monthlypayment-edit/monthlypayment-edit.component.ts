import { Component, OnInit } from '@angular/core';
import { MonthlyPayment } from '../../../Models/monthly-payment';
import { CommonServices } from '../../../Services/common.service';
import { Student } from '../../../Models/student';
import { Standard } from '../../../Models/standard';
import { Fee } from '../../../Models/fee';
import { AcademicMonth } from '../../../Models/academicmonth';
import { MonthlyPaymentService } from '../../../Services/monthly-payment.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-monthlypayment-edit',
  templateUrl: './monthlypayment-edit.component.html',
  styleUrl: './monthlypayment-edit.component.css'
})
export class MonthlypaymentEditComponent implements OnInit {

  public model: MonthlyPayment = new MonthlyPayment();
  public students: Student[] = [];
  public standards: Standard[] = [];
  public fee: Fee[] = [];
  public academicMonthList: AcademicMonth[] = [];
  public selectedStandardId: string = '';
  public monthlyPaymentId!: number;

  constructor(
    private commonService: CommonServices,
    private monthlyPaymentService: MonthlyPaymentService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.monthlyPaymentId = +params['id'];
      this.getMonthlyPaymentDetails(this.monthlyPaymentId);
    });
    this.fetchFees();
    this.fetchAcademicMonths();
    this.fetchStandards();
    this.fetchStudents();
  }

  getMonthlyPaymentDetails(id: number): void {
    this.monthlyPaymentService.getMonthlyPaymentById(id).subscribe(
      (data: MonthlyPayment) => {
        this.model = data;
      },
      error => {
        console.error(error);
      }
    );
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
    this.monthlyPaymentService.updateMonthlyPayment(this.model).subscribe(
      () => {
        this.router.navigate(['/monthlypayment']);
      },
      error => {
        console.error(error);
      }
    );
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
    const filteredFees = this.fee.filter(fee => fee.standardId.toString() === this.selectedStandardId);

    return { students: filteredStudents, fees: filteredFees };
  }

}
