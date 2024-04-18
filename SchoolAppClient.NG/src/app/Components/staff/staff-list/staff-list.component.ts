import { Component, OnInit } from '@angular/core';
import { Staff } from '../../../Models/staff';
import { StaffService } from '../../../Services/staff.service';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrl: './staff-list.component.css'
})

export class StaffListComponent implements OnInit {
  staffList: Staff[] = [];
  errorMessage!: string;

  constructor(private staffService: StaffService) { }

  ngOnInit(): void {
    this.loadStaffList();
  }

  loadStaffList(): void {
    this.staffService.getAllStaffs().subscribe(
      staffs => {
        this.staffList = staffs;        
      },
      error => {
        console.error('Error fetching staff list:', error);
        this.errorMessage = 'An error occurred while fetching the staff list. Please try again later.';
      }
    );
  }
}

