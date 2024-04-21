import { Component, OnInit } from '@angular/core';
import { Examtype } from '../../../Models/examtype';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExamtypeService } from '../../../Services/examtype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-examtype-add',
  templateUrl: './examtype-add.component.html',
  styleUrl: './examtype-add.component.css'
})
export class ExamtypeAddComponent implements OnInit {

  public examType!: Examtype;
  public form!: FormGroup;

  constructor(private examTypeService: ExamtypeService, private router: Router) {

  }
  ngOnInit(): void {
    this.form = new FormGroup({
      examTypeId: new FormControl(0),
      examTypeName: new FormControl('', [Validators.required])
    })
  }
  get examTypeName() {
    return this.form.controls["examTypeName"];
  }

  SaveExamType() {
    this.examTypeService.SaveExamType(this.form.value).subscribe({
      next: () => {
        this.router.navigate(['/exam-types']);
      }
    });
  }





}
