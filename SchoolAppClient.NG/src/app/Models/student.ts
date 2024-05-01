import { ImageUpload } from "./StaticImageModel/imageUpload";
import { Standard } from "./standard";

export class Student {
  studentId!: number;
  admissionNo!: number;
  enrollmentNo!: number;
  uniqueStudentAttendanceNumber!: number;
  studentName!: string;
  imagePath?: string = '';
  imageUpload: ImageUpload = new ImageUpload();
  studentDOB!: Date;
  studentGender!: GenderList;
  studentReligion?: string;
  studentBloodGroup?: string;
  studentNationality?: string;
  studentNIDNumber?: string;
  studentContactNumber1?: string;
  studentContactNumber2?: string;
  studentEmail?: string;
  permanentAddress?: string | null;
  temporaryAddress?: string | null;
  fatherName?: string | null;
  fatherNID?: string | null;
  fatherContactNumber?: string | null;
  motherName?: string | null;
  motherNID?: string | null;
  motherContactNumber?: string | null;
  localGuardianName?: string | null;
  localGuardianContactNumber?: string | null;
  standardId!: number;
  standard?: Standard;
}

export enum GenderList {
  Male = 'Male',
  Female = 'Female',
  Other = 'Other'
}

