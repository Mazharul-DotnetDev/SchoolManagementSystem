import { Component } from '@angular/core';
import { MarkEntryService } from '../../../Services/marks-entry.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MarksEntry } from '../../../Models/marks-entry';

@Component({
  selector: 'app-marksnew-entry-delete',
  templateUrl: './marksnew-entry-delete.component.html',
  styleUrl: './marksnew-entry-delete.component.css'
})
export class MarksnewEntryDeleteComponent {

  markEntryId!: number;
  isDeleting: boolean = false;

  constructor(private markEntryService: MarkEntryService, private router: Router) { }

  deleteMarkEntry() {
    this.isDeleting = true;
    this.markEntryService.deleteMarkEntry(this.markEntryId).subscribe(
      () => {
        console.log('Mark Entry deleted successfully.');
        this.router.navigate(['/marksentrynewList']); 
      },
      error => {
        console.error('Error deleting Mark Entry:', error);
        this.isDeleting = false;
      }
    );
  }
}
