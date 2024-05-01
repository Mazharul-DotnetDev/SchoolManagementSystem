import { CreateExamSubjectWithScheduleVM } from "./create-exam-subject-with-schedule-vm";

export class CreateExamScheduleStandardVM {
 
  examScheduleId!: number;
  standardId!: number;
  examSubjects: CreateExamSubjectWithScheduleVM[] = [];
}
