import { Component, OnInit, ViewChild } from '@angular/core';
import { Staff } from '../../../Models/staff';
import { StaffService } from '../../../Services/staff.service';
import { DetailDataBoundEventArgs, EditSettingsModel, FilterSettingsModel, Grid, GridComponent, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { StaffReportService } from '../../../Services/Reports/staff-report.service';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrl: './staff-list.component.css'
})


export class StaffListComponent implements OnInit {  

  public editSettings?: EditSettingsModel;
  public pageSettings: PageSettingsModel = { pageSize: 5 };
  public filterSettings: FilterSettingsModel = { type: 'FilterBar' };
  public toolbarOptions?: ToolbarItems[] = ['Search',
    'Print',
    'ColumnChooser',
    'Add', 'Edit', 'Delete', 'Update', 'Cancel',
    'PdfExport',
    'ExcelExport',
    'CsvExport'
  ];
  public selectionOptions?: SelectionSettingsModel;
  public searchOptions?: SearchSettingsModel;
  


  staffList: Staff[] = [];
  errorMessage!: string;

  constructor(private staffService: StaffService, private staffReportService: StaffReportService) { }

  ngOnInit(): void {
    this.loadStaffList();

    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.selectionOptions = { mode: 'Row', type: 'Single' };
    this.searchOptions = { fields: ['staffName', 'designation'], operator: 'contains', ignoreCase: true, ignoreAccent: true };
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

  //detailDataBound(e: DetailDataBoundEventArgs) {

  //  var data = e.data as Staff;

  //  let detail = new Grid({
  //    dataSource: data.staffExperiences,
  //    columns: [
  //      { field: 'companyName', headerText: 'companyName', width: 110 },
  //      { field: 'designation', headerText: 'designation', width: 140 }
  //    ]
  //  });
  //  detail.appendTo((e.detailElement as HTMLElement).querySelector('.custom-grid') as HTMLElement);
  //}


  LoadReport() {

    this.staffReportService.GetReport().subscribe((data) => {

      const basedata = "data:application/pdf;base64," + data;
      this.downloadFileObject(basedata);

    }, (error) => {
      console.log('Observable emitted an error: ' + JSON.stringify(error));
    });
  }

  downloadFileObject(base64String: string) {
    const linkSource = base64String;
    const downloadLink = document.createElement("a");
    const fileName = "convertedPDFFile.pdf";
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
  }



}

