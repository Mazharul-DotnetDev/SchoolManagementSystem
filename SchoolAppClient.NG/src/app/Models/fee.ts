import { FeeType } from "./feetype";
import { Standard } from "./standard";

export enum Frequency {
  Monthly = 'Monthly',
  Yearly = 'Yearly',
  Quarterly = 'Quarterly',
  Semesterly = 'Semesterly',
  Biannually = 'Biannually',
  Custom = 'Custom'
}

export class Fee {
  feeId!: number;
  feeTypeId!: number;
  standardId!: number;
  paymentFrequency!: Frequency;
  amount!: number;
  dueDate!: Date;
  standard!: Standard;
  feeType!: FeeType;
  //monthlyPayment!: MonthlyPayment;
  //othersPayment!: OthersPayment;
}
