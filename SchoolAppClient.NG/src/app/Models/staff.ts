import { ImageUpload } from "./StaticImageModel/imageUpload";
import { Department } from "./department";
import { StaffExperience } from "./staff-experience";
import { StaffSalary } from "./staff-salary";

export class Staff {
  staffId!: number;
  staffName!: string;
  uniqueStaffAttendanceNumber!: number;
  gender?: Gender = Gender.Male;
  dob: string | null = null;
  fatherName?: string;
  motherName?: string;
  temporaryAddress?: string;
  permanentAddress?: string;
  imagePath: string = '';
  imageUpload: ImageUpload = new ImageUpload();
  contactNumber1?: string;
  email?: string;
  qualifications?: string;
  joiningDate?: Date;
  designation?: Designation;
  bankAccountName?: string;
  bankAccountNumber?: number;
  bankName?: string;
  bankBranch?: string;
  status?: string;
  departmentId?: number;
  department?: Department;
  staffSalaryId?: number;
  staffSalary?: StaffSalary;
  staffExperiences: StaffExperience[]=[];
}

export enum Gender {
  Male,
  Female,
  Other
}

export enum Designation {
  Superintendent,
  Headmaster,
  Headmistress,
  AssistantPrincipal,
  Dean,
  Director,
  DepartmentChair,
  Professor,
  Instructor,
  Lecturer,
  TeachingAssistant,
  SpecialEducationTeacher,
  SubstituteTeacher,
  Counselor,
  Librarian,
  MediaSpecialist,
  LabTechnician,
  ITSpecialist,
  BusDriver,
  LunchAide,
  Custodian,
  Registrar,
  AdmissionsOfficer,
  BusinessManager,
  DevelopmentOfficer,
  HumanResourcesManager,
  Receptionist,
  Coach,
  SecurityGuard,
  MaintenanceWorker,
  FoodServiceWorker,
  Other
}
