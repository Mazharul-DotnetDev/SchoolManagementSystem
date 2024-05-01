import { Component, OnInit } from '@angular/core';
import { Subject } from '../../../Models/subject';
import { SubjectService } from '../../../Services/subject.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrl: './subject-list.component.css'
})
export class SubjectListComponent implements OnInit {

  subjects: Subject[] = [];
  standardId!: number;

  constructor(
    private subjectService: SubjectService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getSubjects();
  }

  getSubjects(): void {
    this.subjectService.getSubjects().subscribe(data => {
      this.subjects = data;
    });
  }

  deleteSubject(id: number): void {
    if (confirm("Are you sure you want to delete this subject?")) {
      this.subjectService.deleteSubject(id).subscribe(() => {
        this.subjects = this.subjects.filter(subject => subject.subjectId !== id);
      });
    }
  }
}
