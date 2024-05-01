import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subject } from '../../../Models/subject';
import { Standard } from '../../../Models/standard';
import { SubjectService } from '../../../Services/subject.service';
import { StandardService } from '../../../Services/standard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subject-add',
  templateUrl: './subject-add.component.html',
  styleUrl: './subject-add.component.css'
})
export class SubjectAddComponent implements OnInit {

  @ViewChild("subjectForm") subjectForm!: NgForm;
  public model: Subject = new Subject();
  public standardList: Standard[] = [];

  constructor(private subjectService: SubjectService, private router: Router, private standardService: StandardService) { }

  ngOnInit(): void {
    this.loadStandards();
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

  onSubmit(): void {
    if (this.subjectForm.valid) {
      this.subjectService.createSubject(this.model).subscribe(
        () => {
          console.log('Subject added successfully');
          this.router.navigate(['/subjects']);
        },
        (error) => {
          console.error('Error adding subject:', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }

}

