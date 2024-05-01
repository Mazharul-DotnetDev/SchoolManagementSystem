import { Component, OnInit } from '@angular/core';
import { Student } from '../../../Models/student';
import { Standard } from '../../../Models/standard';
import { StudentService } from '../../../Services/student.service';
import { StandardService } from '../../../Services/standard.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageUpload } from '../../../Models/StaticImageModel/imageUpload';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrl: './student-edit.component.css'
})
export class StudentEditComponent implements OnInit {
  studentId!: number;
  students: Student = new Student();
  standards: Standard[] = [];
  errorMessages: string[] = [];

  constructor(
    private studentService: StudentService,
    private standardService: StandardService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    // Fetch standards from the service
    this.standardService.getStandards().subscribe((standards: Standard[]) => this.standards = standards);

    // Load student details based on the route parameter
    this.studentId = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);

    this.loadStudentDetails(this.studentId);
  }

  initializeForm(): void {
    // Initialize form fields if needed
  }

  loadStudentDetails(studentId: number): void {
    // Call the service method to load student details
    this.studentService.GetStudent(studentId).subscribe({
      next: (student: Student) => {
        this.students = student;
        this.students.imageUpload = new ImageUpload();
        if (student.imagePath) {
          this.students.imageUpload.imageData = student.imagePath;
        }
      },
      error: error => {
        console.error('Error loading student details:', error);
      }
    });
  }

  onSubmit(studentForm: NgForm): void {
    if (studentForm.valid) {
      // Update the student details
      this.studentService.UpdateStudent(this.students).subscribe(
        () => {
          console.log('Student details updated successfully');
          this.router.navigate(['/student']);
        },
        error => {
          console.error('Error updating student details:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }

  uploadImage(imageInput: any) {
    var file: File = imageInput.files[0];
    if (file.size > 200 * 1024) {
      alert('max allowed size is 200KB');
      this.errorMessages.push('max allowed size is 200KB');
      return;
    }
    else {
      this.errorMessages = [];
    }
    this.students.imageUpload.getBase64(file);

  }
}

