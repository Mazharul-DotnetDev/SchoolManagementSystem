import { Component, OnInit } from '@angular/core';
import { Staff } from '../../../Models/staff';
import { ActivatedRoute } from '@angular/router';
import { StaffService } from '../../../Services/staff.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-staff-details',
  templateUrl: './staff-details.component.html',
  styleUrl: './staff-details.component.css'
})
export class StaffDetailsComponent implements OnInit {
  staff: Staff = new Staff();
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private staffService: StaffService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getStaffDetails();
  }

  getStaffDetails(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);
    this.staffService.getStaffById(id).subscribe(
      staff => {
        this.staff = staff;
      },
      error => {
        console.error('Error fetching staff details:', error);
        this.errorMessage = 'An error occurred while fetching the staff details. Please try again later.';
      }
    );
  }

  goBack(): void {
    this.location.back();
  }
}
