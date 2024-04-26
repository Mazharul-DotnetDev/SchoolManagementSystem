import { Component, ViewChild } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { StaffSalary } from '../../../Models/staff-salary';
import { Router } from '@angular/router';
import { StaffSalaryService } from '../../../Services/staff-salary.service';

@Component({
  selector: 'app-staff-salary-create',
  templateUrl: './staff-salary-create.component.html',
  styleUrl: './staff-salary-create.component.css'
})
export class StaffSalaryCreateComponent {

  @ViewChild("staffSalaryForm") staffSalaryForm!: NgForm;

  staffSalary: StaffSalary = new StaffSalary();

  constructor(
    private fb: FormBuilder,
    private staffSalaryService: StaffSalaryService,   
    private router: Router)
  { }


  ngOnInit(): void {    
    this.initializeForm();  
  }

  initializeForm(): void {    
  }

  onSubmit(): void {
    // Submit the form
    if (this.staffSalaryForm.valid) {
      // Call the service method to add the staff
      this.staffSalaryService.addStaffSalary(this.staffSalary).subscribe(
        () => {

          console.log('StaffSalary added successfully');

          this.router.navigate(['/staff-salaries']);
        },
        error => {

          console.error('Error adding StaffSalary:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }


}
