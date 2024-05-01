import { Student } from "./student";
import { Subject } from "./subject";

export class Standard {
  standardId!: number;
  standardName!: string;
  standardCapacity!: string;
  //studentCount!: number;
  //subjectCount!: number;
  students: Student[] = [];
  subjects: Subject[] = [];
}
