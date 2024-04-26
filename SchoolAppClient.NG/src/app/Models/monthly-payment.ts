import { AcademicMonth } from "./academicmonth";
import { DueBalance } from "./due-balance";
import { Fee } from "./fee";
import { PaymentDetail } from "./payemnt-details";
import { PaymentMonth } from "./paymentmonth";
import { Student } from "./student";

export class MonthlyPayment {
  monthlyPaymentId!: number;
  studentId!: number;
  totalFeeAmount!: number;
  waver!: number;
  previousDue!: number;
  totalAmount!: number;
  amountPaid!: number;
  amountRemaining!: number;
  paymentDate: Date = new Date();
  student!: Student;

  //feeStructures: { feeStructureId: number }[] = [];

  fees: { feeId: number }[] = [];
  academicMonths: { monthId: number }[] = [];


  paymentMonths: PaymentMonth[] = [];

  paymentDetails: PaymentDetail[] = [];
  dueBalances: DueBalance[] = [];
  /*  balanceSheet: BalanceSheet[]=[];*/
}
