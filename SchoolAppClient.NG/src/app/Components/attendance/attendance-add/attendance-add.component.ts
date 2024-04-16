import { Component } from '@angular/core';
import { Attendance } from '../../../Models/attendance';
import { AttendanceService } from '../../../Services/attendance.service';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AttList } from '../../../Models/attlist';

@Component({
  selector: 'app-attendance-add',
  templateUrl: './attendance-add.component.html',
  styleUrl: './attendance-add.component.css'
})


export class AttendanceAddComponent {
  attendanceForm: FormGroup;
  errormessage!: string;

  public listData: AttList[] = [];
  constructor(
    private formBuilder: FormBuilder,
    private attendanceService: AttendanceService,
    private router: Router
  ) {
    this.attendanceForm = this.formBuilder.group({
      date: ['', Validators.required],
      type: ['', Validators.required],
      attendanceIdentificationNumber: ['', Validators.compose([Validators.required, this.validateIdentificationNumber.bind(this)])],
      description: [''],
      isPresent: [true, Validators.required]
    });
  }

  validateIdentificationNumber(control: FormControl): { [s: string]: boolean } {
    if (!control.value) {
      return {};
    }

    const isUnique = this.checkUniqueness(control.value);

    if (!isUnique) {
      return { 'notUnique': true };
    }

    return {};
  }

  checkUniqueness(identificationNumber: number): boolean {
    // Placeholder for uniqueness check
    return true;
  }

  addAttendance(): void {
    if (this.attendanceForm.invalid) {
      return;
    }

    const attendance: Attendance = this.attendanceForm.value;
    this.attendanceService.addAttendance(attendance)
      .subscribe(
        () => {
          this.router.navigate(['/attendanceList']);
        },
        error => {
          this.errormessage = error.error;
          console.error('Error adding attendance:', error);
        }
      );
  }

  getError(controlName: string, errorType: string): boolean | undefined {
    return this.attendanceForm.get(controlName)?.hasError(errorType);
  }

  LoadListData() {
    const attendance: Attendance = this.attendanceForm.value;
    this.attendanceService.getAttendanceListData(attendance).subscribe(
      (res) => {
        this.listData = res;
      },
      error => {
        this.errormessage = error.error;
        console.error('Error adding attendance:', error);
      }
    )
  }

}



















//export class AttendanceAddComponent {
//  attendanceForm: FormGroup;

//  constructor(
//    private formBuilder: FormBuilder,
//    private attendanceService: AttendanceService,
//    private router: Router
//  ) {
//    this.attendanceForm = this.formBuilder.group({
//      date: ['', Validators.required],
//      type: ['', Validators.required],
//      attendanceIdentificationNumber: ['', Validators.required],
//      description: [''],
//      isPresent: [true, Validators.required]
//    });
//  }

//  addAttendance(): void {
//    if (this.attendanceForm.invalid) {
//      return;
//    }

//    const attendance: Attendance = this.attendanceForm.value;
//    this.attendanceService.addAttendance(attendance)
//      .subscribe(
//        () => {
//          this.router.navigate(['/attendanceList']);
//        },
//        error => {
//          console.error('Error adding attendance:', error);

//        }
//      );
//  }
//}
