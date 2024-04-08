export class Mark {
  markId!: number;
  totalMarks!: number;
  passMarks!: number;
  obtainedScore!: number;
  grade!: Grade;
  passStatus!: Pass;
  markEntryDate?: Date;
  feedback?: string;
  staffId!: number;
  studentId!: number;
  subjectId!: number;
}

export enum Grade {
  A = 'A',
  B = 'B',
  C = 'C',
  D = 'D',
  E = 'E',
  F = 'F',
}

export enum Pass {
  Passed = 'Passed',
  Failed = 'Failed',
  UnderConsideration = 'UnderConsideration',
  SpecialConsideration = 'SpecialConsideration',
  Withdrawn = 'Withdrawn',
  UnderJurisdiction = 'UnderJurisdiction',
}
