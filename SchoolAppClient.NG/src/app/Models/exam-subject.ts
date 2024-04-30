import { ExamScheduleStandard } from "./exam-schedule-standard";
import { Examtype } from "./examtype";
import { Subject } from "./subject";

export class ExamSubject {
  examSubjectId: number = 0;
  examScheduleStandardId !: number;
  subjectId !: number;
  examTypeId !: number;
  examDate: Date = new Date();
  examStartTime!: Date;
  examEndTime!: Date;
  subject!: Subject;
  examType!: Examtype;
  examScheduleStandard!: ExamScheduleStandard;
}
