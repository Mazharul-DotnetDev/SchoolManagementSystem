import { Component, OnInit } from '@angular/core';
import { Attendance } from '../../../Models/attendance';
import { AttendanceService } from '../../../Services/attendance.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrl: './attendance-list.component.css'
})
export class AttendanceListComponent implements OnInit {
  attendances: Attendance[] = [];

  constructor(private attendanceService: AttendanceService, private router: Router) { }

  ngOnInit(): void {
    this.getAttendances();
  }

  //getAttendances(): void {
  //  this.attendanceService.getAttendances()
  //    .subscribe(attendances => this.attendances = attendances);
  //}


  getAttendances(): void {
    this.attendanceService.getAttendances()
      .subscribe(
        attendances => {
          this.attendances = attendances;
        },
        error => {
          console.error('Error fetching attendances:', error);
          
        }
      );
  }

}
