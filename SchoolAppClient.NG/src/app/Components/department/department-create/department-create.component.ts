import { Component, OnInit } from '@angular/core';
import { Department } from '../../../Models/department';
import { DepartmentServices } from '../../../Services/department.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-department-create',
  templateUrl: './department-create.component.html',
  styleUrl: './department-create.component.css'
})
export class DepartmentCreateComponent implements OnInit {

  public model: Department = new Department;


  constructor(private departmentService: DepartmentServices, private router: Router) { }

  ngOnInit(): void {

  }

  createFeeType(): void {
    this.departmentService.createDepartment(this.model).subscribe(() => {
      this.router.navigate(['/departments']);
    });
  }

}
