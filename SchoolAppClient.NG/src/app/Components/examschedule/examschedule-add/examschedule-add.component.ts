import { Component, OnInit } from '@angular/core';
import { ExamSchedule } from '../../../Models/exam-schedule';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExamScheduleService } from '../../../Services/exam-schedule.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-examschedule-add',
  templateUrl: './examschedule-add.component.html',
  styleUrl: './examschedule-add.component.css'
})
export class ExamscheduleAddComponent implements OnInit {

  public examschedule!: ExamSchedule;
  public form !: FormGroup;
  constructor(private examScheduleService: ExamScheduleService, private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      examScheduleId: new FormControl(0),
      examScheduleName: new FormControl('', [Validators.required]),
    })
  }

  get examScheduleName() {
    return this.form.controls["examScheduleName"]
  }
  SaveExamSchedule() {
    this.examScheduleService.SaveExamSchedule(this.form.value).subscribe({
      next: () => { this.router.navigate(['/examSchedule']) }
    })
  }
}

