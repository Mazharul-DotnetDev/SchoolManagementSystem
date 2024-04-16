import { Component, OnInit } from '@angular/core';
import { Fee } from '../../../Models/fee';
import { Standard } from '../../../Models/standard';
import { FeeType } from '../../../Models/FeeType';
import { FeeService } from '../../../Services/fee-service.service';
import { CommonServices } from '../../../Services/common.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-fee-create',
  templateUrl: './fee-create.component.html',
  styleUrl: './fee-create.component.css'
})
export class FeeCreateComponent implements OnInit {
  public fee: Fee = new Fee();
  public frequencies: string[] = [];
  public standards: Standard[] = [];
  public feeTypes: FeeType[] = [];
  constructor(private feeService: FeeService, private commonService: CommonServices, private router: Router) { }

  ngOnInit(): void {


    this.fee = new Fee();
    this.loadStandards();
    this.loadFeeTypes();
    this.loadFrequencyEnum();

  }


  loadFrequencyEnum() {
    this.commonService.getFrequencyEnum().subscribe((data: string[]) => {
      this.frequencies = data;
    });
  }

  loadFeeTypes() {
    this.commonService.getAllFeeType().subscribe(feeTypes => {
      this.feeTypes = feeTypes;
    });
  }

  loadStandards() {


    this.commonService.getAllStandards().subscribe(standards => {
      this.standards = standards;
    });
  }

  createFee() {
    this.feeService.createFee(this.fee).subscribe(
      () => {
        console.log('Fee created successfully');

        this.router.navigate(['/fees']);
      },
      (error: HttpErrorResponse) => {
        if (error.status === 400 && error.error && error.error.errors) {
          // Handle validation errors
          const validationErrors = error.error.errors;
          // Display validation errors to the user
          console.error('Validation errors:', validationErrors);
        } else {
          // Handle other types of errors
          console.error('Error creating fee:', error);
        }
      }
    );
  }

}
