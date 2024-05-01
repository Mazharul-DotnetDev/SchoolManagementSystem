import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { MarksService } from '../../../Services/marks.service';
import { Router } from '@angular/router';
import { Grade, Mark, Pass } from '../../../Models/marks';
import { Staff } from '../../../Models/staff';
import { Student } from '../../../Models/student';
import { Subject } from '../../../Models/subject';
import { SubjectService } from '../../../Services/subject.service';
import { StaffService } from '../../../Services/staff.service';
import { StudentService } from '../../../Services/student.service';

@Component({
  selector: 'app-marks-add',
  templateUrl: './marks-add.component.html',
  styleUrl: './marks-add.component.css'
})

export class MarksAddComponent implements OnInit {

  @ViewChild("markForm") markForm!: NgForm;
  /*markForm!: FormGroup;*/

  /*mark: Mark = new Mark();*/
  public mark!: Mark;

  public staff!: Staff[];
  /*staff: Staff[] = [];*/

  public student!: Student[];
  /*student: Student[] = [];*/

  public subject!: Subject[];
  /*subject: Subject[] = [];*/  


  constructor(
    private fb: FormBuilder,
    private marksService: MarksService,
    private studentService: StudentService,
    private subjectService: SubjectService,
    private staffService: StaffService,
    private router: Router)
  {
    /*this.staff = [];*/
  }

  ngOnInit(): void {
    this.mark = new Mark();

    this.initializeForm();


    this.studentService.GetStudents().subscribe((data) => {
      this.student = data;
    });
    this.subjectService.getSubjects().subscribe((data) => {
      this.subject = data;
    });
    this.staffService.getAllStaffs().subscribe((data) => {
      this.staff = data;
    });


    
    //this.studentService?.getAllStudents().subscribe((stds: Student[]) => this.student = stds);
    //this.subjectService?.getAllSubjects().subscribe((sbjcts: Subject[]) => this.subject = sbjcts);
    //this.staffService?.getAllStaffs().subscribe((stfs: Staff[]) => this.staff = stfs);
 

  }

  initializeForm(): void {
       
  }

  onSubmit(): void {
    // Submit the form
    if (this.markForm.valid) {
      // Call the service method to add the mark
      this.marksService.addMark(this.mark).subscribe(
        () => {

          console.log('Mark added successfully');

          this.router.navigate(['/staff-list']);
        },
        error => {

          console.error('Error adding mark:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }

}




//export class MarksAddComponent implements OnInit {
//  mark: Mark = new Mark(); 
//  errorMessage!: string;
//  grades = Object.keys(Grade).map(key => key);
//  passes = Object.keys(Pass).map(key => key);


//  constructor(private markService: MarksService, private router: Router) { }

//  ngOnInit(): void {
   
//  }

//  onSubmit() {

//    this.markService.addMark(this.mark)
//      .subscribe(
//        {
//          next: () => {
//            this.router.navigate(['/marksList'])
//          },
//          error: (error) => {
//            //alert(JSON.stringify(error));
//            console.error(error);
//            this.errorMessage = error.error;

//          }
//        }

//      //  createdMark => this.router.navigate(['/marksList']),
//      //// Redirect after successful creation
//      //  error => {
//      //    this.errorMessage = error.message;
//      //    alert(error.message);
//      //    console.error(error.message);
//      //  }
//      );
//  }
//}










//export class MarksAddComponent implements OnInit {
//  markForm: FormGroup = new FormGroup({});

//  constructor(
//    private formBuilder: FormBuilder,
//    private markService: MarksService,
//    private router: Router
//  ) { }

//  ngOnInit(): void {
//    this.initializeForm();
//  }

//  initializeForm(): void {
//    this.markForm = this.formBuilder.group({
//      totalMarks: [null, Validators.required],
//      passMarks: [null, Validators.required],
//      obtainedScore: [null, Validators.required],
//      grade: [null, Validators.required],
//      passStatus: [null, Validators.required],
//      markEntryDate: [null],
//      feedback: [null],
//      staffId: [null, Validators.required],
//      studentId: [null, Validators.required],
//      subjectId: [null, Validators.required]
//    });
//  }

//  onSubmit(): void {
//    if (this.markForm.invalid) {
//      return;
//    }

//    const mark: Mark = this.markForm.value;
//    this.markService.addMark(mark)
//      .subscribe({
//        next: () => {
//          console.log('Mark added successfully');
//          this.router.navigate(['/marksList']); // Redirect to marks list after adding
//        },
//        error: (error) => {
//          console.error('Error adding mark:', error);
//          // Handle error (e.g., display error message to user)
//        }
//      });
//  }
//}
