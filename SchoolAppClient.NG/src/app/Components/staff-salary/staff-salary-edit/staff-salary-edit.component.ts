import { Component } from '@angular/core';
import { StaffSalary } from '../../../Models/staff-salary';
import { FormBuilder, NgForm } from '@angular/forms';
import { StaffSalaryService } from '../../../Services/staff-salary.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-staff-salary-edit',
  templateUrl: './staff-salary-edit.component.html',
  styleUrl: './staff-salary-edit.component.css'
})
export class StaffSalaryEditComponent {

  staffSalaryId!: number;
  staffSalary: StaffSalary = new StaffSalary();
  errorMessages: string[] = [];

  constructor(
    private staffSalaryService: StaffSalaryService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
       
    /*this.staffSalaryId = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);*/
    this.staffSalaryId = this.route.snapshot.params['id'];

    this.loadStaffSalaryDetails(this.staffSalaryId);
  }

  initializeForm(): void {

  }


  loadStaffSalaryDetails(staffSalaryId: number): void {
    
    this.staffSalaryService.getStaffSalaryById(staffSalaryId).subscribe(

      (staffSalary: StaffSalary) => {
        this.staffSalary = staffSalary;        

      },

      error => {
        console.error('Error loading staff details:', error);
      }
    );
  }

  onSubmit(staffSalaryForm: NgForm): void {
    if (staffSalaryForm.valid) {
      
      this.staffSalaryService.updateStaffSalary(this.staffSalaryId, this.staffSalary).subscribe(
        () => {
          console.log('StaffSalary details updated successfully');
          this.router.navigate(['/staff-salaries']);
        },
        error => {
          console.error('Error updating StaffSalary details:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }

  

}
