import { Component, OnInit } from '@angular/core';
import { FeeTypeService } from '../../../Services/feetype.service';
import { Router } from '@angular/router';
import { FeeType } from '../../../Models/feetype';
import { EditSettingsModel, FilterSettingsModel, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-feetype-list',
  templateUrl: './feetype-list.component.html',
  styleUrl: './feetype-list.component.css'
})
export class FeetypeListComponent implements OnInit {

  feeTypes: FeeType[] = [];
  searchfeeTypeId: number | undefined;
  confirmationDialogVisible: boolean = false;
  feeTypeIdToDelete: number | undefined;

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

  constructor(private feeTypeService: FeeTypeService) { }

  ngOnInit(): void {
    this.getFeeTypes();
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.selectionOptions = { mode: 'Row', type: 'Single' };
    this.searchOptions = { fields: ['feeTypeId', 'typeName'], operator: 'contains', ignoreCase: true, ignoreAccent: true };
  }

  getFeeTypes(): void {
    this.feeTypeService.getFeeTypes().subscribe(data => {
      this.feeTypes = data;
    });
  }

  confirmDelete(id: number): void {
    this.confirmationDialogVisible = true;
    this.feeTypeIdToDelete = id;
  }

  deleteFeeType(): void {
    if (this.feeTypeIdToDelete !== undefined) {
      this.feeTypeService.deleteFeeType(this.feeTypeIdToDelete).subscribe(() => {

        this.feeTypes = this.feeTypes.filter(feeType => feeType.feeTypeId !== this.feeTypeIdToDelete);

        this.confirmationDialogVisible = false;
        this.feeTypeIdToDelete = undefined;
      });
    }
  }

  closeConfirmationDialog(): void {
    this.confirmationDialogVisible = false;
    this.feeTypeIdToDelete = undefined;
  }
}
