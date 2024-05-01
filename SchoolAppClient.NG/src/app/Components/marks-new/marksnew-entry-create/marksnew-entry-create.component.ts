import { Component, OnInit, ViewChild } from '@angular/core';
import { GradesSystem, MarksEntry, PassFailStatus, StudentMarksDetails } from '../../../Models/marks-entry';
import { MarkEntryService } from '../../../Services/marks-entry.service';
import { FormBuilder, NgForm } from '@angular/forms';
import { Staff } from '../../../Models/staff';
import { Router } from '@angular/router';
import { ExamSchedule } from '../../../Models/exam-schedule';
import { Examtype } from '../../../Models/examtype';
import { Subject } from '../../../Models/subject';
import { Standard } from '../../../Models/standard';
import { StudentService } from '../../../Services/student.service';
import { ExamScheduleService } from '../../../Services/exam-schedule.service';
import { ExamtypeService } from '../../../Services/examtype.service';
import { SubjectService } from '../../../Services/subject.service';
import { StandardService } from '../../../Services/standard.service';
import { Student } from '../../../Models/student';
import { ExamScheduleVm } from '../../../Models/exam-schedule-vm';
import { StaffService } from '../../../Services/staff.service';


@Component({
  selector: 'app-marksnew-entry-create',
  templateUrl: './marksnew-entry-create.component.html',
  styleUrl: './marksnew-entry-create.component.css'
})
export class MarkEntryCreateComponent implements OnInit {

  @ViewChild("entryForm") entryForm!: NgForm;
  //@ViewChild("LoadData") LoadData!: HTMLElement;

  markEntry: MarksEntry = new MarksEntry();

  //studentMarksDetails: StudentMarksDetails[] = [];

  staffList: Staff[] = [];

  examSchedules: ExamSchedule = new ExamSchedule();

  examtypes: Examtype[] = [];

  subjects: Subject[] = [];

  standards: Standard[] = [];

  students: Student[] = [];


  examSchedulesVM: ExamScheduleVm[] = [];

  // Define a property to hold enum values for the select dropdown
  gradesSystemValues = Object.keys(GradesSystem).filter(key => isNaN(+key));

  passFailStatusValues = Object.values(PassFailStatus);


  constructor(
    private fb: FormBuilder,
    private markEntryService: MarkEntryService,
    private staffService: StaffService,
    private studentService: StudentService,
    private examScheduleService: ExamScheduleService,
    private examtypeService: ExamtypeService,
    private subjectService: SubjectService,
    private standardService: StandardService,
    private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();

    this.standardService.getStandards().subscribe((depts: Standard[]) => this.standards = depts);



    this.staffService.getAllStaffs().subscribe((depts: Staff[]) => this.staffList = depts);

    this.subjectService.getSubjects().subscribe((depts: Subject[]) => this.subjects = depts);

    
    this.examScheduleService.GetExamSchedules().subscribe((depts: ExamScheduleVm[]) => this.examSchedulesVM = depts);

    this.examtypeService.GetdbsExamType().subscribe((salaries: Examtype[]) => this.examtypes = salaries);
  }

  onSubmit(): void {
    if (this.entryForm.valid) {
      //alert(JSON.stringify(this.markEntry));
      //return;
      this.markEntryService.createMarkEntry(this.markEntry).subscribe(
        (response) => {
          console.log('Mark Entry created successfully:', response);
          
          this.entryForm.resetForm();
          this.router.navigate(['/marksentrynewList']);

        },
        (error) => {
          console.error('Error creating Mark Entry:', error);
        }
      );
    }
  }

  initializeForm(): void {
    
  }



  loadStudentsMark(): void {
    this.markEntryService.GetStudents(this.markEntry).subscribe(
      (students) => {
        this.markEntry.studentMarksDetails.length = 0;
        this.markEntry.studentMarksDetails = students;
      },
      (error) => {
        console.error('Error fetching students:', error);
      }
    );
  }
}
