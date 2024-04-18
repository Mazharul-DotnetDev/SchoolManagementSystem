import { Component, OnInit } from '@angular/core';
import { Department } from '../../../Models/department';
import { DepartmentService } from '../../../Services/department.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.css'
})
export class DepartementListComponent implements OnInit {
  departments!: Department[];

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments() {
    this.departmentService.getAllDepartments().subscribe(
      (data: Department[]) => {
        this.departments = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
