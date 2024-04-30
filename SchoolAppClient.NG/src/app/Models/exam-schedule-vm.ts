import { ExamScheduleStandardForExamScheduleVm } from "./exam-schedule-standard-for-exam-schedule-vm";

export class ExamScheduleVm {
  examScheduleId !: number;
  examScheduleName !: string;
  examScheduleStandards !: ExamScheduleStandardForExamScheduleVm[];
}
