import { Component, OnInit } from '@angular/core';
import { MarksEntry, StudentMarksDetails } from '../../../Models/marks-entry';
import { ActivatedRoute } from '@angular/router';
import { MarkEntryService } from '../../../Services/marks-entry.service';

@Component({
  selector: 'app-marksnew-entry-details',
  templateUrl: './marksnew-entry-details.component.html',
  styleUrl: './marksnew-entry-details.component.css'
})
export class MarkEntryDetailsComponent implements OnInit {
  /*markEntry: MarksEntry | null = null;*/
  markEntry!: MarksEntry ;
  //studentDetails: StudentMarksDetails[] = [];
  /*markEntryId!: number;*/
  errorMessage: string | undefined;

  constructor(private route: ActivatedRoute, private markEntryService: MarkEntryService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const markEntryId = params.get('id') as unknown as number;
      /*const markEntryId = this.route.snapshot.paramMap.get('id');*/
      this.getMarkEntryById(markEntryId);
    });
  }

  getMarkEntryById(id: number): void {
    this.markEntryService.getMarkEntryById(id).subscribe(
      (result: MarksEntry) => {
        /*this.markEntry = result as MarksEntry;*/
        this.markEntry = result;
        // Fetch student details for the markEntry
        //this.fetchStudentDetails();
      },
      error => {
        console.log('Error fetching MarkEntry:', error);
      }
    );
  }

  fetchStudentDetails(): void {
    this.markEntryService.GetStudents(this.markEntry).subscribe(
      (result: StudentMarksDetails[]) => {
        //this.studentDetails = result;
      },
      error => {
        console.log('Error fetching Student Details:', error);
      }
    );
  }
}
