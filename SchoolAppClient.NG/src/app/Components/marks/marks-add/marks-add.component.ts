import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { MarksService } from '../../../Services/marks.service';
import { Router } from '@angular/router';
import { Grade, Mark, Pass } from '../../../Models/marks';

@Component({
  selector: 'app-marks-add',
  templateUrl: './marks-add.component.html',
  styleUrl: './marks-add.component.css'
})

export class MarksAddComponent implements OnInit {
  mark: Mark = new Mark(); 
  errorMessage!: string;
  grades = Object.keys(Grade).map(key => key);
  passes = Object.keys(Pass).map(key => key);


  constructor(private markService: MarksService, private router: Router) { }

  ngOnInit(): void {
   
  }

  onSubmit() {

    this.markService.addMark(this.mark)
      .subscribe(
        {
          next: () => {
            this.router.navigate(['/marksList'])
          },
          error: (error) => {
            //alert(JSON.stringify(error));
            console.error(error);
            this.errorMessage = error.error;

          }
        }

      //  createdMark => this.router.navigate(['/marksList']),
      //// Redirect after successful creation
      //  error => {
      //    this.errorMessage = error.message;
      //    alert(error.message);
      //    console.error(error.message);
      //  }
      );
  }
}










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
