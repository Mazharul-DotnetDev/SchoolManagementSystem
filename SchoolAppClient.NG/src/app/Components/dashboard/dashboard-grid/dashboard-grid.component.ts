import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../../Services/student.service';
import { StandardService } from '../../../Services/standard.service';
import { StaffService } from '../../../Services/staff.service';
import { DepartmentServices } from '../../../Services/department.service';

@Component({
  selector: 'app-dashboard-grid',
  templateUrl: './dashboard-grid.component.html',
  styleUrl: './dashboard-grid.component.css'
})
export class DashboardComponent implements OnInit {
  studentCount: number = 0;
  staffCount: number = 0;
  departmentCount: number = 0;
  standardCount: number = 0;



  constructor(private studentService: StudentService, private staffService: StaffService, private departmentService: DepartmentServices, private standardService: StandardService) { }

  ngOnInit(): void {
    this.getStudentCount();
    this.getStaffCount();
    this.getDepartmentCount();
    this.getStandardCount();
  }

  getStudentCount(): void {
    this.studentService.GetStudents().subscribe(students => {
      this.studentCount = students.length;
    });
  }
  getStaffCount(): void {
    this.staffService.getAllStaffs().subscribe(staffs => {
      this.staffCount = staffs.length;
    });
  }
  getDepartmentCount(): void {
    this.departmentService.getAllDepartment().subscribe(defartments => {
      this.departmentCount = defartments.length;
    });
  }
  getStandardCount(): void {
    this.standardService.getStandards().subscribe(standards => {
      this.standardCount = standards.length;
    });
  }
}
