import { Component, OnInit } from '@angular/core';
import { Attendance } from '../../../Models/attendance';
import { AttendanceService } from '../../../Services/attendance.service';
import { Router } from '@angular/router';
import { EditSettingsModel, FilterSettingsModel, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { StaffReportService } from '../../../Services/Reports/staff-report.service';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrl: './attendance-list.component.css'
})
export class AttendanceListComponent implements OnInit {
  attendances: Attendance[] = [];

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




  constructor(private attendanceService: AttendanceService, private router: Router, private staffReportService: StaffReportService) { }

  ngOnInit(): void {
    this.getAttendances();

    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.selectionOptions = { mode: 'Row', type: 'Single' };
    this.searchOptions = { fields: ['staffName', 'designation'], operator: 'contains', ignoreCase: true, ignoreAccent: true };

  }

  //getAttendances(): void {
  //  this.attendanceService.getAttendances()
  //    .subscribe(attendances => this.attendances = attendances);
  //}


  getAttendances(): void {
    this.attendanceService.getAttendances()
      .subscribe(
        attendances => {
          this.attendances = attendances;
        },
        error => {
          console.error('Error fetching attendances:', error);
          
        }
      );
  }


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
