import { Component, OnInit } from '@angular/core';
import { Examtype } from '../../../Models/examtype';
import { ExamtypeService } from '../../../Services/examtype.service';

@Component({
  selector: 'app-examtype-list',
  templateUrl: './examtype-list.component.html',
  styleUrl: './examtype-list.component.css'
})
export class ExamtypeListComponent implements OnInit {
  public examtypes: Examtype[] = [];

  constructor(private examTypeService: ExamtypeService) {

  }
  ngOnInit(): void {
    this.LoadData();
  }
  LoadData() {
    this.examTypeService.GetdbsExamType().subscribe((data: Examtype[]) => {
      this.examtypes = data;
      console.log(data);
    }, (error) => {
      console.log('Observable emitted an error: ' + error);
    }
    );


  }
  DeleteExamType(examType: Examtype) {
    let confirmDelete: boolean = confirm(`Delete ${examType.examTypeName}?`);
    if (confirmDelete) {
      this.examTypeService.DeleteExamType(examType.examTypeId
      ).subscribe(() => {
        this.LoadData();
      }, (error) => {
        console.log('Observable emitted an error: ' + error);
      });
    }
  }
}

