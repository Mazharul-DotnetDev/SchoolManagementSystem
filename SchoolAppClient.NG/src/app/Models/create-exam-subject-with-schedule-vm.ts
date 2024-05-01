export class CreateExamSubjectWithScheduleVM {
  subjectId!: number;
  examTypeId!: number;
  examDate: Date = new Date();
  examStartTime!: string;
  examEndTime!: string;

}
