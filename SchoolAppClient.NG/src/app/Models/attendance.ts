export class Attendance {
  attendanceId!: number;
  date!: Date;
  type!: AttendanceType;
  attendanceIdentificationNumber!: number;
  description?: string;
  isPresent!: boolean;
}

export enum AttendanceType {
  Student = 0,
  Staff = 1
}
