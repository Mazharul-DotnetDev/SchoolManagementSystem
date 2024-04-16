import { Component, OnInit } from '@angular/core';
import { MarksService } from '../../../Services/marks.service';
import { Mark } from '../../../Models/marks';
import { Router } from '@angular/router';

@Component({
  selector: 'app-marks-list',
  templateUrl: './marks-list.component.html',
  styleUrl: './marks-list.component.css'
})
export class MarksListComponent implements OnInit {
  marks: Mark[] = [];
  
  constructor(private markService: MarksService, private router: Router) { }

  ngOnInit(): void {
    this.getAllMarks();
  }

  getAllMarks(): void {
    this.markService.getAllMarks()
      .subscribe({
        next: (marks: Mark[]) => {
          this.marks = marks;
        },
        error: (error) => {
          console.error('#Developer# Error fetching marks:', error);
        }
      });
  }

  editMark(markId: number): void {
    this.router.navigate(['/marks/edit', markId]);
  }

  deleteMark(markId: number): void {
    if (confirm('Are you sure you want to delete this mark?')) {
      this.markService.deleteMark(markId).subscribe(() => {
        // Delete successful, update the marks list
        this.getAllMarks();
      }, error => {
        console.error('Error deleting mark:', error);
      });
    }
  }


}
