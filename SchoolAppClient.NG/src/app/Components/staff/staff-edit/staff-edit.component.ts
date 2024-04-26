import { Component, OnInit } from '@angular/core';
import { Staff } from '../../../Models/staff';
import { Department } from '../../../Models/department';
import { StaffSalary } from '../../../Models/staff-salary';
import { StaffExperience } from '../../../Models/staff-experience';
import { StaffService } from '../../../Services/staff.service';
import { DepartmentServices } from '../../../Services/department.service';
import { StaffSalaryService } from '../../../Services/staff-salary.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ImageUpload } from '../../../Models/StaticImageModel/imageUpload';

@Component({
  selector: 'app-staff-edit',
  templateUrl: './staff-edit.component.html',
  styleUrl: './staff-edit.component.css'
})
export class StaffEditComponent implements OnInit {
  staffId!: number;
  staff: Staff = new Staff();
  departments: Department[] = [];
  salaries: StaffSalary[] = [];
  //staffExperiences: StaffExperience[] = [];
  errorMessages: string[] = [];

  constructor(
    private staffService: StaffService,
    private departmentService: DepartmentServices,
    private staffSalaryService: StaffSalaryService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    //this.staffExperiences = [];
  }

  ngOnInit(): void {
    // Fetch departments and staff salaries from the service
    this.departmentService.getAllDepartment().subscribe((depts: Department[]) => this.departments = depts);
    this.staffSalaryService.getStaffSalaries().subscribe((salaries: StaffSalary[]) => this.salaries = salaries);

    // Load staff details based on the route parameter
    this.staffId = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);

    this.loadStaffDetails(this.staffId);
  }

  initializeForm(): void {

  }


  loadStaffDetails(staffId: number): void {
    // Call the service method to load staff details
    this.staffService.getStaffById(staffId).subscribe(
      (staff: Staff) => {
        this.staff = staff;
        this.staff.imageUpload = new ImageUpload();
        if (staff.imagePath) {
          this.staff.imageUpload.imageData = staff.imagePath;
        }


      },
      error => {
        console.error('Error loading staff details:', error);
      }
    );
  }

  onSubmit(staffForm: NgForm): void {
    if (staffForm.valid) {
      // Update the staff details
      this.staffService.updateStaff(this.staffId, this.staff).subscribe(
        () => {
          console.log('Staff details updated successfully');
          this.router.navigate(['/staff-list']);
        },
        error => {
          console.error('Error updating staff details:', error);
        }
      );
    } else {
      // Form is invalid, display validation errors
      console.log('Form is invalid');
    }
  }

  addExperience(): void {
    this.staff.staffExperiences?.push({} as StaffExperience);
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
    this.staff.imageUpload.getBase64(file);

  }
 
  DeleteExperience(index: number) {

    const remItem = this.staff.staffExperiences.splice(index, 1);
  }
}
