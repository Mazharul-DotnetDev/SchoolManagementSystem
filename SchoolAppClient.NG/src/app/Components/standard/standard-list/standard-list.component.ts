import { Component, OnInit } from '@angular/core';
import { Standard } from '../../../Models/standard';
import { StandardService } from '../../../Services/standard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-standard-list',
  templateUrl: './standard-list.component.html',
  styleUrl: './standard-list.component.css'
})
export class StandardListComponent implements OnInit {

  standard: Standard[] = [];
  standardId!: number;

  constructor(
    private standarService: StandardService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getStandards();
  }

  getStandards(): void {
    this.standarService.getStandards().subscribe(data => {
      this.standard = data;
    });
  }

  deleteStandard(id: number): void {
    if (confirm("Are you sure you want to delete this fee type?")) {
      this.standarService.deleteStandard(id).subscribe(() => {

        this.standard = this.standard.filter(standard => standard.standardId !== id);
      });
    }
  }
}
