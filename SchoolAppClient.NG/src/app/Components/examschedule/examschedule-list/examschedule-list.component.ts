import { Component, OnInit } from '@angular/core';
import { ExamScheduleVm } from '../../../Models/exam-schedule-vm';
import { ExamScheduleService } from '../../../Services/exam-schedule.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-examschedule-list',
  templateUrl: './examschedule-list.component.html',
  styleUrl: './examschedule-list.component.css'
})
export class ExamscheduleListComponent implements OnInit {

  public examSchedules !: ExamScheduleVm[];
  constructor(private examScheduleService: ExamScheduleService, private router: Router) { }

  ngOnInit(): void {
    this.LoadExamSchedules();
  }

  LoadExamSchedules() {
    this.examScheduleService.GetExamSchedules().subscribe
      (examSchedules => {
        this.examSchedules = examSchedules;
      });
  }


  deleteExamSchedules(id: number): void {
    if (confirm("Are you sure you want to delete this fee type?")) {
      this.examScheduleService.DeleteExamSchedule(id).subscribe(() => {

        this.examSchedules = this.examSchedules.filter(examSchedules => examSchedules.examScheduleId !== id);
      });
    }

  }
}
