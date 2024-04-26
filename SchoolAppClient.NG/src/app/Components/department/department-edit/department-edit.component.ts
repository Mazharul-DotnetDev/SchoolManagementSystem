import { Component, OnInit } from '@angular/core';
import { Department } from '../../../Models/department';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartmentServices } from '../../../Services/department.service';

@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrl: './department-edit.component.css'
})
export class DepartmentEditComponent implements OnInit {
  public model: Department = new Department();
  public departmentId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private departmentService: DepartmentServices
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.departmentId = +params['id'];
      this.getDepartmentDetails(this.departmentId);
    });
  }

  getDepartmentDetails(id: number): void {
    this.departmentService.getDepartmentById(id).subscribe(
      (data: Department) => {
        this.model = data;
      },
      error => {
        console.error(error);
      }
    );
  }

  updateDepartment(): void {
    this.departmentService.updateDepartment(this.model).subscribe(
      () => {
        this.router.navigate(['/departments']);
      },
      error => {
        console.error(error);
      }
    );
  }
}
