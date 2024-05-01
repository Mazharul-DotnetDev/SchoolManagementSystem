import { Standard } from "./standard";

export class Subject {
  subjectId!: number;
  subjectName!: string | null;
  subjectCode!: number | null;
  standardId!: number | null;
  standard!: Standard | null;
}
