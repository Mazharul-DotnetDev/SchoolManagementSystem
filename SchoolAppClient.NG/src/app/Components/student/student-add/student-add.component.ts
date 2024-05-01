import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { Student } from '../../../Models/student';
import { Standard } from '../../../Models/standard';
import { StudentService } from '../../../Services/student.service';
import { StandardService } from '../../../Services/standard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrl: './student-add.component.css'
})
export class StudentAddComponent implements OnInit {


  @ViewChild("studentForm") studentForm!: NgForm;

  students: Student = new Student();
  standards: Standard[] = [];


  //studentForm!: FormGroup;
  //standards: Standard[] = [];
  //genders = Object.values(GenderList);

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private standardService: StandardService,
    private router: Router

    //private fb: FormBuilder,
    //private standardService: StandardService, // Update path accordingly
    //private studentService: StudentService, // Update path accordingly
    //private router: Router
  ) { }



  ngOnInit(): void {

    this.initializeForm();
    this.standardService.getStandards().subscribe((depts: Standard[]) => this.standards = depts);

    //this.initializeForm();
    //this.standardService.getAllStandards().subscribe((standards: Standard[]) => {
    //  this.standards = standards;
    //});
  }

  initializeForm(): void {

  }

  onSubmit(): void {
    // Submit the form
    if (this.studentForm.valid) {
      // Call the service method to add the staff
      this.studentService.SaveStudent(this.students).subscribe(
        () => {

          console.log('students added successfully');

          this.router.navigate(['/student']);
        },
        error => {

          console.error('Error adding student:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }



  //onSubmit(): void {
  //  if (this.studentForm.valid) {
  //    const newStudent: Student = this.studentForm.value;
  //    this.studentService.createSubject(newStudent).subscribe(
  //      () => {
  //        console.log('Student added successfully');
  //        this.router.navigate(['/student-list']); // Navigate to student list page
  //      },
  //      error => {
  //        console.error('Error adding student:', error);
  //      }
  //    );
  //  } else {
  //    console.log('Form is invalid');
  //  }
  //}





  uploadImage(imageInput: any) {
    var file: File = imageInput.files[0];
    if (file.size > 200 * 1024) {
      alert('max allowed size is 200KB');
      return;
    }
    this.students.imageUpload.getBase64(file);

  }
}

