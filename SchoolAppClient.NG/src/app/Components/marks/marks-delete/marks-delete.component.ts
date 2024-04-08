import { Component, OnInit } from '@angular/core';
import { Mark } from '../../../Models/marks';
import { ActivatedRoute, Router } from '@angular/router';
import { MarksService } from '../../../Services/marks.service';

@Component({
  selector: 'app-marks-delete',
  templateUrl: './marks-delete.component.html',
  styleUrl: './marks-delete.component.css'
})
export class MarksDeleteComponent implements OnInit {
  mark: Mark = new Mark();
  message: string = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private markService: MarksService
  ) { }

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id') || ''); // Convert to number
    this.markService.getMarkById(id).subscribe(mark => this.mark = mark);
  }

  deleteMark(): void {
    this.markService.deleteMark(this.mark.markId).subscribe(() => {
      // Delete successful, navigate back to the list
      this.message = 'Mark deleted successfully.';
      setTimeout(() => {
        this.router.navigate(['/marksList']);
      }, 1000); // Redirect after 1 seconds
    });
  }

  goBack(): void {
    // Navigate back to the list without deleting
    this.router.navigate(['/marksList']);
  }
}

