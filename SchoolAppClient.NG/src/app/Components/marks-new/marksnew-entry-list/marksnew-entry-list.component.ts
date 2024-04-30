import { Component } from '@angular/core';
import { MarksEntry } from '../../../Models/marks-entry';
import { MarkEntryService } from '../../../Services/marks-entry.service';
import { EditSettingsModel, FilterSettingsModel, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-marksnew-entry-list',
  templateUrl: './marksnew-entry-list.component.html',
  styleUrl: './marksnew-entry-list.component.css'
})
export class MarksnewEntryListComponent {

  markEntries: MarksEntry[] = [];

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

  constructor(private markEntryService: MarkEntryService) { }

  ngOnInit(): void {
    this.loadMarkEntries();

    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.selectionOptions = { mode: 'Row', type: 'Single' };
    this.searchOptions = { fields: ['staffName', 'designation'], operator: 'contains', ignoreCase: true, ignoreAccent: true };

  }

  loadMarkEntries() {
    this.markEntryService.getAllMarkEntries().subscribe(markEntries => {
      this.markEntries = markEntries;
    });
  }

  getStudentsDetails(markEntry: MarksEntry) {
    markEntry.studentMarksDetails = [];
    this.markEntryService.GetStudents(markEntry).subscribe(students => {
      markEntry.studentMarksDetails = students;
    });
  }

}
