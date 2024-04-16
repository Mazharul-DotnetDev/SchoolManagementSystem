import { Component, OnInit } from '@angular/core';
import { Fee } from '../../../Models/fee';
import { Router } from '@angular/router';
import { FeeService } from '../../../Services/fee-service.service';

@Component({
  selector: 'app-fee-list',
  templateUrl: './fee-list.component.html',
  styleUrl: './fee-list.component.css'
})
export class FeeListComponent implements OnInit {
  public fees!: Fee[];

  constructor(private feeService: FeeService, private router: Router) { }

  ngOnInit(): void {
    this.loadFees();
  }

  loadFees() {
    this.feeService.getAllFees().subscribe(fees => {
      this.fees = fees;
    });
  }

  deleteFee(id: number) {
    this.feeService.deleteFee(id).subscribe(() => {
      // Filter out the deleted fee from the list
      this.fees = this.fees.filter(fee => fee.feeId !== id);
    });
  }
}
