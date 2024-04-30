import { ExamSchedule } from "./exam-schedule";
import { ExamSubject } from "./exam-subject";
import { Standard } from "./standard";

export class ExamScheduleStandard {
  examScheduleStandardId: number = 0;
  examScheduleId!: number;

  standardId!: number;
  standard!: Standard;
  examSchedule!: ExamSchedule;
  examSubjects: ExamSubject[] = [];
}
