import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Staff } from '../../../Models/staff';
import { Department } from '../../../Models/department';
import { StaffSalary } from '../../../Models/staff-salary';
import { StaffService } from '../../../Services/staff.service';
/*import { DepartmentService } from '../../../Services/department.service';*/
import { StaffSalaryService } from '../../../Services/staff-salary.service';
import { StaffExperience } from '../../../Models/staff-experience';
import { Router } from '@angular/router';
import { DepartmentServices } from '../../../Services/department.service';

@Component({
  selector: 'app-staff-create',
  templateUrl: './staff-create.component.html',
  styleUrl: './staff-create.component.css'
})
export class StaffCreateComponent implements OnInit {
  @ViewChild("staffForm") staffForm!: NgForm;
  //staffForm!: FormGroup;
  staff: Staff = new Staff();
  departments: Department[] = [];
  salaries: StaffSalary[] = [];
  staffExperiences: StaffExperience[] = [];

  constructor (
    private fb: FormBuilder,
    private staffService: StaffService,
    private departmentService: DepartmentServices,
    private staffSalaryService: StaffSalaryService,
    private router: Router  )
  {
    this.staffExperiences = [];
  }

  ngOnInit(): void {
    // Initialize form controls and validators
    this.initializeForm();

    // Fetch departments and staff salaries from the service
    this.departmentService.getAllDepartment().subscribe((depts: Department[]) => this.departments = depts);
    this.staffSalaryService.getStaffSalaries().subscribe((salaries: StaffSalary[]) => this.salaries = salaries);
  }

  // Initialize form controls and validators
  initializeForm(): void {
    //this.staffForm = this.fb.group({
    //  staffName: ['', Validators.required],
    //  uniqueStaffAttendanceNumber: ['', Validators.required],
    //  gender: ['', Validators.required],
    //  dob: ['', Validators.required],
    //  departmentId: ['', Validators.required],
    //  staffSalaryId: ['', Validators.required],
    //  // Add more form controls for other properties with validators as needed
    //});
  }

  // Add a new instance of StaffExperience to the staff's experiences array
  addExperience(): void {
    this.staff.staffExperiences?.push({} as StaffExperience);
  }

  // Submit the form
  onSubmit(): void {
    // Submit the form
    if (this.staffForm.valid) {
      // Call the service method to add the staff
      this.staffService.addStaff(this.staff).subscribe(
        () => {
          
          console.log('Staff added successfully');
         
          this.router.navigate(['/staff-list']); 
        },
        error => {
          
          console.error('Error adding staff:', error);
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
      return;
    }
    this.staff.imageUpload.getBase64(file);

  }

  deleteExperience(index:number): void {
   let deletedExp = this.staff.staffExperiences.splice(index,1);
  }

}
