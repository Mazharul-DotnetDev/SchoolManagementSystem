import { Component, OnInit } from '@angular/core';
import { FeeType } from '../../../Models/FeeType';
import { FeeTypeService } from '../../../Services/feetype.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feetype-list',
  templateUrl: './feetype-list.component.html',
  styleUrl: './feetype-list.component.css'
})
export class FeetypeListComponent implements OnInit {

  feeTypes: FeeType[] = [];
  searchfeeTypeId: number | undefined;

  constructor(
    private feeTypeService: FeeTypeService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getFeeTypes();
  }

  getFeeTypes(): void {
    this.feeTypeService.getFeeTypes().subscribe(data => {
      this.feeTypes = data;
    });
  }

  deleteFeeType(id: number): void {
    if (confirm("Are you sure you want to delete this fee type?")) {
      this.feeTypeService.deleteFeeType(id).subscribe(() => {
        // After successful deletion, remove the deleted fee type from the list
        this.feeTypes = this.feeTypes.filter(feeType => feeType.feeTypeId !== id);
      });
    }
  }
}
