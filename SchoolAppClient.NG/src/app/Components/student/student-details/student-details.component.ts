import { Component, OnInit } from '@angular/core';
import { Student } from '../../../Models/student';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from '../../../Services/student.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrl: './student-details.component.css'
})
export class StudentDetailsComponent implements OnInit {
  student: Student = new Student();
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getStudentDetails();
  }

  getStudentDetails(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);
    this.studentService.GetStudent(id).subscribe(
      student => {
        this.student = student;
      },
      error => {
        console.error('Error fetching student details:', error);
        this.errorMessage = 'An error occurred while fetching the student details. Please try again later.';
      }
    );
  }

  goBack(): void {
    this.location.back();
  }
}

