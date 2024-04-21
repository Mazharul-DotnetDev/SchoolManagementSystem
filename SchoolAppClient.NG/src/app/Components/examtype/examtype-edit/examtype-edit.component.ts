import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExamtypeService } from '../../../Services/examtype.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Examtype } from '../../../Models/examtype';

@Component({
  selector: 'app-examtype-edit',
  templateUrl: './examtype-edit.component.html',
  styleUrl: './examtype-edit.component.css'
})
export class ExamtypeEditComponent implements OnInit {
  id!: number;
  examType!: Examtype;
  form!: FormGroup;

  constructor(private examTypeService: ExamtypeService, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.LoadData();
    this.form = new FormGroup({
      examTypeId: new FormControl(this.examType.examTypeId),
      examTypeName: new FormControl(this.examType.examTypeName, [Validators.required]),
    })

  }

  LoadData() {
    this.examTypeService.GetExamType(this.id).subscribe((data: Examtype) => {
      this.examType = data;

      this.form = new FormGroup({
        examTypeId: new FormControl(this.examType.examTypeId),
        examTypeName: new FormControl(this.examType.examTypeName, [Validators.required]),
      })
      console.log(data);
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    });
  }
  get examTypeName() {
    return this.form.controls["examTypeName"];
  }


  UpdateExamType() {
    this.examTypeService.UpdateExamType(this.form.value).subscribe({
      next: () => {
        this.router.navigate(['/exam-types']);
      }
    });
  }





}

