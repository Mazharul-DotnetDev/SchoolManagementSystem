import { Component } from '@angular/core';
import { MarksEntry } from '../../../Models/marks-entry';
import { MarkEntryService } from '../../../Services/marks-entry.service';

@Component({
  selector: 'app-marksnew-entry-list',
  templateUrl: './marksnew-entry-list.component.html',
  styleUrl: './marksnew-entry-list.component.css'
})
export class MarksnewEntryListComponent {

  markEntries: MarksEntry[] = [];

  constructor(private markEntryService: MarkEntryService) { }

  ngOnInit(): void {
    this.loadMarkEntries();
  }

  loadMarkEntries() {
    this.markEntryService.getAllMarkEntries().subscribe(markEntries => {
      this.markEntries = markEntries;
    });
  }

  getStudentsDetails(markEntry: MarksEntry) {
    markEntry.studentMarksDetails = [];
    this.markEntryService.GetStudents(markEntry).subscribe(students => {
      markEntry.studentMarksDetails = students;
    });
  }

}
