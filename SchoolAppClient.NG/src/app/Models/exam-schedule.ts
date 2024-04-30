import { ExamScheduleStandard } from "./exam-schedule-standard";

export class ExamSchedule {
  examScheduleId!: number;
  examScheduleName!: string;
  examScheduleStandards: ExamScheduleStandard[] = [];
}
