import { Component, OnInit } from '@angular/core';
import { Staff } from '../../../Models/staff';
import { ActivatedRoute, Router } from '@angular/router';
import { StaffService } from '../../../Services/staff.service';

@Component({
  selector: 'app-staff-delete',
  templateUrl: './staff-delete.component.html',
  styleUrl: './staff-delete.component.css'
})
export class StaffDeleteComponent implements OnInit {
  staffId!: number;
  staff!: Staff;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private staffService: StaffService
  ) { }

  ngOnInit(): void {
    this.staffId = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);
    this.loadStaffDetails();
  }

  loadStaffDetails(): void {
    // Call your staff service to get the staff details by ID
    this.staffService.getStaffById(this.staffId).subscribe(
      (staff: Staff) => {
        this.staff = staff;
      },
      error => {
        console.error('Error fetching staff details:', error);
        // Handle error here
      }
    );
  }

  deleteStaff(): void {
    // Call your staff service to delete the staff by ID
    this.staffService.deleteStaff(this.staffId).subscribe(
      () => {
        console.log('Staff deleted successfully');
        // Redirect to staff list page after deletion
        this.router.navigate(['/staff-list']);
      },
      error => {
        console.error('Error deleting staff:', error);
        // Handle error here
      }
    );
  }

  cancel(): void {
    // Redirect back to the staff list page if the user cancels deletion
    this.router.navigate(['/staff-list']);
  }
}
