import { Component, OnInit } from '@angular/core';
import { Department } from '../../../Models/department';
import { DepartmentService } from '../../../Services/department.service';
import { DetailDataBoundEventArgs, EditSettingsModel, FilterSettingsModel, Grid, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.css'
})
export class DepartementListComponent implements OnInit {
  departments!: Department[];

  public editSettings?: EditSettingsModel;

  public pageSettings: PageSettingsModel = { pageSize: 5 };
  public filterSettings: FilterSettingsModel = { type: 'FilterBar' };




  public toolbarOptions?: ToolbarItems[] = ['Search',
    //'Print',
    'ColumnChooser',
    //'Add', 'Edit', 'Delete', 'Update', 'Cancel',
    //'PdfExport',
    //'ExcelExport',
    //'CsvExport'
  ];

  public selectionOptions?: SelectionSettingsModel;
  public searchOptions?: SearchSettingsModel;



  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.loadDepartments();
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.selectionOptions = { mode: 'Row', type: 'Single' };
    this.searchOptions = { fields: ['departmentId', 'departmentName'], operator: 'contains', ignoreCase: true, ignoreAccent: true };
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

  //detailDataBound(e: DetailDataBoundEventArgs) {

  //  var data = e.data as Department;

  //  let detail = new Grid({
  //    dataSource: data,
  //    columns: [
  //      { field: 'name', headerText: 'Name', width: 110 },
  //      { field: 'productNumber', headerText: 'Product Number', width: 140 },
  //      { field: 'size', headerText: 'Size', width: 40 }
  //    ]
  //  });
  //  detail.appendTo((e.detailElement as HTMLElement).querySelector('.custom-grid') as HTMLElement);
  //}


}
