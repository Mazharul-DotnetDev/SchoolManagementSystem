import { ExamSubjectVM } from "./exam-subject-vm";

export class ExamScheduleStandardVm {
  examScheduleStandardId!: number;

  examScheduleId!: number;
  standardId!: number;
  standardName!: string;
  examScheduleName!: string;
  examSubjects!: ExamSubjectVM[]
}
