import { Component, OnInit } from '@angular/core';
import { StaffSalary } from '../../../Models/staff-salary';
import { StaffSalaryService } from '../../../Services/staff-salary.service';

@Component({
  selector: 'app-staff-salary-list',
  templateUrl: './staff-salary-list.component.html',
  styleUrl: './staff-salary-list.component.css'
})
export class StaffSalaryListComponent implements OnInit {

  staffSalaries: StaffSalary[] = [];

  constructor(private staffSalaryService: StaffSalaryService) { }

  ngOnInit(): void {
    this.loadStaffSalaries();
  }

  loadStaffSalaries(): void {
    this.staffSalaryService.getStaffSalaries()
      .subscribe((data: StaffSalary[]) => {
        this.staffSalaries = data;
      });
  }

}
