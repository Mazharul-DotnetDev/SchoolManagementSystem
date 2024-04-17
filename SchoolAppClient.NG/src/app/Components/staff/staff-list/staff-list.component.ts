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

  constructor(private staffService: StaffService) { }

  ngOnInit(): void {
    this.getAllStaffs();
  }

  getAllStaffs(): void {
    this.staffService.getAllStaffs()
      .subscribe(
        (data: Staff[]) => {
          this.staffList = data;
        },
        error => {
          console.log('Error fetching staffs:', error);
        }
      );
  }
}
