import { ExamSchedule } from "./exam-schedule";
import { Examtype } from "./examtype";
import { Staff } from "./staff";
import { Standard } from "./standard";
/*import { Standard } from "./standard";*/
import { Student } from "./student";
import { Subject } from "./subject";


export class MarksEntry {
  markEntryId!: number;
  markEntryDate?: Date;
  staffId!: number;
  staff?: Staff;
  examScheduleId!: number;
  examSchedule?: ExamSchedule;
  examTypeId!: number;
  examType?: Examtype;
  subjectId!: number;
  subject?: Subject;

  standardId!: number;
  /*standard?: Standard;*/
  standard?: Standard;
  totalMarks: number = 100;
  passMarks: number = 40;

  studentMarksDetails: StudentMarksDetails[] = [];

  //students: Student[] = [];
  //obtainedScore: number = 45;
  //grade: GradesSystem = GradesSystem.A;
  //passStatus: PassFailStatus = PassFailStatus.Passed;
  //feedback?: string;
}

export enum GradesSystem {
  A = 0,
  B = 1,
  C = 2,
  D = 3,
  E = 4,
  F = 5,
  NotApplicable = 6
}

export enum PassFailStatus {
  Passed,
  Failed,
  UnderConsideration,
  SpecialConsideration,
  Withdrawn,
  UnderJurisdiction
}


export class StudentMarksDetails {
  studentId !: number;
  studentName !: string;
  obtainedScore: number = 0;

  /*grade ?: string;*/

  grade!: string;//; GradesSystem = GradesSystem.A;

  /*passStatus ?: string;*/

  passStatus?: string;// PassFailStatus = PassFailStatus.Passed;
  feedback?: string;
  //Student
}


