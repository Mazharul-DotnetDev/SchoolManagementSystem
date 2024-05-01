import { Component, OnInit } from '@angular/core';
import { ExamScheduleStandardVm } from '../../../Models/exam-schedule-standard-vm';
import { Router } from '@angular/router';
import { ExamScheduleStandardService } from '../../../Services/exam-schedule-standard.service';


@Component({
  selector: 'app-exam-schedule-standards-list',
  templateUrl: './exam-schedule-standards-list.component.html',
  styleUrl: './exam-schedule-standards-list.component.css'
})
export class ExamScheduleStandardsListComponent implements OnInit {
  public examScheduleStandards!: ExamScheduleStandardVm[];
  constructor(private examScheduleStandardService: ExamScheduleStandardService, private router: Router) { }

  ngOnInit(): void {
    this.loadExamScheduleStandards();
  }

  loadExamScheduleStandards() {
    this.examScheduleStandardService.GetExamScheduleStandards().subscribe(examScheduleStandards => {
      this.examScheduleStandards = examScheduleStandards;
    });
  }


  DeleteExamScheduleStandard(id: number): void {
    if (confirm("Are you sure you want to delete this Exam Schedule Standard?")) {
      this.examScheduleStandardService.DeleteExamScheduleStandard(id).subscribe(() => {

        this.examScheduleStandards = this.examScheduleStandards.filter(examScheduleStandards => examScheduleStandards.examScheduleStandardId !== id);
      });
    }

  }

}

