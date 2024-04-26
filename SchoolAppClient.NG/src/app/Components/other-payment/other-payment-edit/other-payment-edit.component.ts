import { Component, OnInit } from '@angular/core';
import { OthersPayment } from '../../../Models/other-payment';
import { Student } from '../../../Models/student';
import { Standard } from '../../../Models/standard';
import { Fee } from '../../../Models/fee';
import { CommonServices } from '../../../Services/common.service';
import { OtherPaymentService } from '../../../Services/other-payment.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-other-payment-edit',
  templateUrl: './other-payment-edit.component.html',
  styleUrl: './other-payment-edit.component.css'
})
export class OtherpaymentEditComponent implements OnInit {
  public model: OthersPayment = new OthersPayment();
  public students: Student[] = [];
  public standards: Standard[] = [];
  public fee: Fee[] = [];
  public otherPaymentId!: number;
  public selectedStandardId: string = '';


  constructor(
    private commonService: CommonServices,
    private otherPaymentService: OtherPaymentService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.otherPaymentId = +params['id'];
      this.getOtherPaymentDetails(this.otherPaymentId);
    });
    this.fetchFees();

    this.fetchStandards();
    this.fetchStudents();

  }
  getOtherPaymentDetails(id: number): void {
    this.otherPaymentService.getOtherPayemtnById(id).subscribe(
      (data: OthersPayment) => {
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
    this.otherPaymentService.updateOthersPayment(this.model).subscribe(
      () => {
        this.router.navigate(['/otherpayment']);
      },
      error => {
        console.error(error);
      }
    );
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
