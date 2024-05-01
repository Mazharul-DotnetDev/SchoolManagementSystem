import { Component, OnInit } from '@angular/core';
import { GetExamScheduleOptionsResponse } from '../../../Models/get-exam-schedule-options-response';
import { Standard } from '../../../Models/standard';
import { Subject } from '../../../Models/subject';
import { Examtype } from '../../../Models/examtype';
import { ExamScheduleStandardVm } from '../../../Models/exam-schedule-standard-vm';
import { UpdateExamScheduleStandardVM } from '../../../Models/update-exam-schedule-standard-vm';
import { ExamScheduleService } from '../../../Services/exam-schedule.service';
import { ExamtypeService } from '../../../Services/examtype.service';
import { StandardService } from '../../../Services/standard.service';
import { SubjectService } from '../../../Services/subject.service';
import { ExamScheduleStandardService } from '../../../Services/exam-schedule-standard.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-exam-schedule-standards-edit',
  templateUrl: './exam-schedule-standards-edit.component.html',
  styleUrl: './exam-schedule-standards-edit.component.css'
})
export class ExamScheduleStandardsEditComponent implements OnInit {

  examScheduleList: GetExamScheduleOptionsResponse[] = [];
  standardList: Standard[] = [];
  subjectList: Subject[] = [];
  examTypeList: Examtype[] = [];
  examScheduleStandardVm!: ExamScheduleStandardVm
  model!: UpdateExamScheduleStandardVM;
  id!: number;
  constructor(
    private examScheduleService: ExamScheduleService,
    private examTypeService: ExamtypeService,
    private standardService: StandardService,
    private subjectService: SubjectService,
    private examScheduleStandardsService: ExamScheduleStandardService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.LoadStandards();
    this.LoadSubjects();
    this.LoadExamTypes();
    this.LoadExamSchedules();
    this.LoadData();
  }


  OnSubmit(): void {
    this.examScheduleStandardsService.updateExamScheduleStandards(this.model).subscribe({
      next: () => {
        this.router.navigate(['/examScheduleStandard']);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }




  LoadExamSchedules() {
    this.examScheduleService.GetExamScheduleOptions().subscribe((data: GetExamScheduleOptionsResponse[]) => {
      this.examScheduleList = data;
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    });
  }

  LoadStandards() {
    this.standardService.getStandards().subscribe((data: Standard[]) => {
      this.standardList = data;
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    });
  }

  LoadSubjects() {
    this.subjectService.getSubjects().subscribe((data: Subject[]) => {
      this.subjectList = data;
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    });
  }

  LoadExamTypes() {
    this.examTypeService.GetdbsExamType().subscribe((data: Examtype[]) => {
      this.examTypeList = data;
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    });
  }

  LoadData(): void {
    this.examScheduleStandardsService.GetExamScheduleStandardsByID(this.id).subscribe((data: ExamScheduleStandardVm) => {

      this.model = new UpdateExamScheduleStandardVM();
      this.model.examScheduleStandardId = data.examScheduleStandardId;
      this.model.examScheduleId = data.examScheduleId;
      this.model.standardId = data.standardId;
      this.model.examSubjects = data.examSubjects;
    }, (error: string) => {
      console.log('Observable emitted an error: ' + error);
    });
  }

  AddExamSubject() {
    this.model.examSubjects.push({
      subjectId: 0,
      examTypeId: 0,
      examDate: new Date(),
      examStartTime: '',
      examEndTime: '',
    })
  }

  DeleteExamSubject(index: number) {
    this.model.examSubjects.splice(index, 1);
  }

}
