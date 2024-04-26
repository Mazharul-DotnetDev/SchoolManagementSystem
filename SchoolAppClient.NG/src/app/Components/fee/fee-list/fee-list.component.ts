import { Component, OnInit } from '@angular/core';
import { Fee } from '../../../Models/fee';
import { Router } from '@angular/router';
import { FeeService } from '../../../Services/fee-service.service';
import { EditSettingsModel, FilterSettingsModel, PageSettingsModel, SearchSettingsModel, SelectionSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-fee-list',
  templateUrl: './fee-list.component.html',
  styleUrl: './fee-list.component.css'
})
export class FeeListComponent implements OnInit {
  public fees: Fee[] = [];
  confirmationDialogVisible: boolean = false;
  feeIdToDelete: number | undefined;

  public editSettings: EditSettingsModel = {
    allowEditing: true,
    allowAdding: false,
    allowDeleting: false,
    mode: 'Normal'
  };

  public toolbarOptions?: ToolbarItems[] = ['Search', 'ColumnChooser'];

  public selectionOptions: SelectionSettingsModel = {
    mode: 'Row',
    type: 'Single'
  };

  public searchOptions: SearchSettingsModel = {
    fields: ['feeId', 'feeName'],
    operator: 'contains',
    ignoreCase: true,
    ignoreAccent: true
  };

  public pageSettings: PageSettingsModel = {
    pageSize: 10
  };

  public filterSettings: FilterSettingsModel = {
    type: 'Menu'
  };

  constructor(private feeService: FeeService) { }

  ngOnInit(): void {
    this.loadFees();
    this.searchOptions = { fields: ['feeId', 'feeType.typeName'], operator: 'contains', ignoreCase: true, ignoreAccent: true };
  }

  loadFees() {
    this.feeService.getAllFees().subscribe(fees => {
      this.fees = fees;
    });
  }

  confirmDelete(id: number): void {
    this.confirmationDialogVisible = true;
    this.feeIdToDelete = id;
  }

  deleteFee(): void {
    if (this.feeIdToDelete !== undefined) {
      this.feeService.deleteFee(this.feeIdToDelete).subscribe(() => {
        this.fees = this.fees.filter(fee => fee.feeId !== this.feeIdToDelete);
        this.closeConfirmationDialog();
      });
    }
  }

  closeConfirmationDialog(): void {
    this.confirmationDialogVisible = false;
    this.feeIdToDelete = undefined;
  }
}
