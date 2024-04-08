import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MarksService } from '../../../Services/marks.service';
import { Grade, Mark, Pass } from '../../../Models/marks';

@Component({
  selector: 'app-marks-edit',
  templateUrl: './marks-edit.component.html',
  styleUrl: './marks-edit.component.css'
})
export class MarksEditComponent implements OnInit {
  markId: number | null = null;
  mark: Mark = new Mark();

  grades: string[] = Object.values(Grade); 
  passStatuses: string[] = Object.values(Pass); 

  constructor(private route: ActivatedRoute, private router: Router, private markService: MarksService) { }

  ngOnInit(): void {
    this.markId = this.route.snapshot.params['id'];
    this.getMark();
  }

  getMark(): void {
    if (this.markId !== null) {
      this.markService.getMarkById(this.markId)
        .subscribe({
          next: (mark: Mark) => {
            this.mark = mark;
          },
          error: (error) => {
            console.error('#Developer# Error fetching mark:', error);
          }
        });
    }
  }

  updateMark(): void {
    if (this.markId !== null) {
      this.markService.updateMark(this.markId, this.mark)
        .subscribe({
          next: (res) => {
           /* alert(res);*/
            console.log('Mark updated successfully!');
            
            this.router.navigate(['/marksList']);
          },
          error: (error) => {
            /*alert(JSON.stringify(error));*/
            console.error('#Developer# Error updating mark:', error);
          }
        });
    }
  }
}
