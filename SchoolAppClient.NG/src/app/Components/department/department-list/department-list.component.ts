import { Component, OnInit, ViewChild } from '@angular/core';
import { Department } from '../../../Models/department';

import { DetailDataBoundEventArgs, EditSettingsModel, FilterSettingsModel, Grid, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { DepartmentServices } from '../../../Services/department.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.css'
})
export class DepartmentListComponent implements OnInit {
  @ViewChild('grid') grid: any;

  public departments: Department[] = [];
  public confirmationDialogVisible: boolean = false;
  public departmentIdToDelete: number | undefined;
  public searchName: string = '';

  public pageSettings: PageSettingsModel = { pageSize: 5 };
  public filterSettings: FilterSettingsModel = { type: 'Menu' };
  public searchSettings: SearchSettingsModel = {
    fields: ['departmentName'],
    operator: 'contains',
    ignoreCase: true
  };

  constructor(private departmentService: DepartmentServices, private router: Router) { }

  ngOnInit(): void {
    this.getDepartments();
  }

  getDepartments(): void {
    this.departmentService.getAllDepartment().subscribe(data => {
      this.departments = data;
    });
  }

  confirmDelete(id: number): void {
    this.confirmationDialogVisible = true;
    this.departmentIdToDelete = id;
  }

  deleteDepartment(): void {
    if (this.departmentIdToDelete !== undefined) {
      this.departmentService.deleteDepartment(this.departmentIdToDelete).subscribe(() => {
        this.departments = this.departments.filter(department => department.departmentId !== this.departmentIdToDelete);
        this.closeConfirmationDialog();
      });
    }
  }

  closeConfirmationDialog(): void {
    this.confirmationDialogVisible = false;
    this.departmentIdToDelete = undefined;
  }

  customNameFilter(args: any): void {
    const filterValue = this.searchName.toLowerCase();
    args.dataSource = this.departments.filter(department => department.departmentName.toLowerCase().includes(filterValue));
  }

  customNameSearch(): void {
    this.grid.search(this.searchName);
  }
}
