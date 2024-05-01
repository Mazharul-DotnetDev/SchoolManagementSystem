import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subject } from '../../../Models/subject';
import { Standard } from '../../../Models/standard';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectService } from '../../../Services/subject.service';
import { StandardService } from '../../../Services/standard.service';

@Component({
  selector: 'app-subject-edit',
  templateUrl: './subject-edit.component.html',
  styleUrl: './subject-edit.component.css'
})
export class SubjectEditComponent implements OnInit {
  @ViewChild("subjectForm") subjectForm!: NgForm;
  public model: Subject = new Subject();
  public subjectId!: number;
  public standardList: Standard[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private subjectService: SubjectService,
    private standardService: StandardService
  ) { }

  ngOnInit(): void {
    this.subjectId = this.route.snapshot.params['id'];
    this.loadStandards();
    this.getSubjectDetails(this.subjectId);

  }

  getSubjectDetails(id: number): void {
    this.subjectService.getSubjectById(id).subscribe(
      (data: Subject) => {
        this.model = data;
      },
      error => {
        console.error(error);
      }
    );
  }
  loadStandards(): void {
    this.standardService.getStandards().subscribe(
      (data: Standard[]) => {
        this.standardList = data;
      },
      (error) => {
        console.log('Observable emitted an error: ' + error);
      }
    );
  }
  updateSubject(): void {
    this.subjectService.updateSubject(this.model).subscribe(
      () => {
        this.router.navigate(['/subjects']);
      },
      error => {
        console.error(error);
      }
    );
  }
}
