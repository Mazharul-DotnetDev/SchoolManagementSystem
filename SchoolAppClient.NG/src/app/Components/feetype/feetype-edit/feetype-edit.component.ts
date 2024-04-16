import { Component, OnInit } from '@angular/core';
//import { FeeType } from '../../../Models/feetype';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { FeeTypeService } from '../../../Services/feetype.service';
import { FeeType } from '../../../Models/FeeType';
//import { FeeType } from '../../../Models/FeeType';

@Component({
  selector: 'app-feetype-edit',
  templateUrl: './feetype-edit.component.html',
  styleUrl: './feetype-edit.component.css'
})
export class FeetypeEditComponent implements OnInit {
  public model: FeeType = new FeeType();
  public typeId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private feeTypeService: FeeTypeService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.typeId = +params['id'];
      this.getTypeDetails(this.typeId);
    });
  }

  getTypeDetails(id: number): void {
    this.feeTypeService.getFeeTypeById(id).subscribe(
      (data: FeeType) => {
        this.model = data;
      },
      error => {
        console.error(error);
      }
    );
  }

  updateFeeType(): void {
    this.feeTypeService.updateFeeType(this.model).subscribe(
      () => {
        this.router.navigate(['/fee-types']);
      },
      error => {
        console.error(error);
      }
    );
  }

  deleteFeeType(): void {
    if (confirm("Are you sure you want to delete this fee type?")) {
      this.feeTypeService.deleteFeeType(this.model.feeTypeId).subscribe(
        () => {
          this.router.navigate(['/fee-types']);
        },
        error => {
          console.error(error);
        }
      );
    }
  }
}
