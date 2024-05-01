import { Component, OnInit } from '@angular/core';
import { ExamScheduleVm } from '../../../Models/exam-schedule-vm';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExamScheduleService } from '../../../Services/exam-schedule.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-examschedule-edit',
  templateUrl: './examschedule-edit.component.html',
  styleUrl: './examschedule-edit.component.css'
})
export class ExamscheduleEditComponent implements OnInit {
  id!: number;
  examSchedule!: ExamScheduleVm;
  form!: FormGroup;

  constructor(private examScheduleService: ExamScheduleService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.LoadData();
    this.form = new FormGroup({
      examScheduleId: new FormControl(this.examSchedule.examScheduleId),
      examScheduleName: new FormControl(this.examSchedule.examScheduleName, [Validators.required]),
    })
  }

  LoadData() {
    this.examScheduleService.GetExamScheduleById(this.id).subscribe((data: ExamScheduleVm) => {
      this.examSchedule = data;
      this.form = new FormGroup({
        examScheduleId: new FormControl(this.examSchedule.examScheduleId),
        examScheduleName: new FormControl(this.examSchedule.examScheduleName, [Validators.required]),
      })
      console.log(data);
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    }
    );
  }

  get examScheduleName() {
    return this.form.controls["examScheduleName"];
  }

  UpdateExamSchedule() {
    this.examScheduleService.UpdateExamSchedule
      (this.form.value).subscribe({
        next: () => {
          this.router.navigate(['/examSchedule']);
        }
      })
  }

}

