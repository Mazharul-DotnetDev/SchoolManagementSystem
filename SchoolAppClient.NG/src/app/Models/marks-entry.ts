import { ExamSchedule } from "./exam-schedule";
import { Examtype } from "./examtype";
import { Staff } from "./staff";
import { Standard } from "./standard";
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
  A,
  B,
  C,
  D,
  E,
  F,
  NotApplicable
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
  obtainedScore ?: number;
  grade ?: string;
  passStatus ?: string;
  feedback?: string;
}


