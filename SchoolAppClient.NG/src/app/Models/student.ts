import { Standard } from "./standard";

export class Student {
  studentId!: number;
  admissionNo!: number;
  enrollmentNo!: number;
  studentName!: string;
  studentDOB!: Date;
  standardId!: number;
  standard!: Standard;
}

export enum GenderList {
  Male = 'Male',
  Female = 'Female',
  Other = 'Other'
}
