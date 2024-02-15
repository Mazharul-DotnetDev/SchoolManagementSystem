using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    /*
    -- Purpose: In a school management system, the FeePayments table would be used to record and manage fee transactions made by students. For example, a student named ABC makes a payment of $500 for the semester. He receives a 10% discount because of an early payment incentive. He pays $450 online, and the system records these details in the FeePayments table. The record includes the total fee, applied discount, total paid, payment mode, and date.
    Example:
    Recording a student's tuition payment: TotalFee = $1000, DiscountPercent = 5%, DiscountAmt = $50, PreviousDue = $0, Fine = $0, GrandTotal = $950, TotalPaid = $950, ModeOfPayment = "Cash", PaymentModeDetails = "Paid at the school office", PaymentDate = 2024-02-05, PaymentDue = $0.

    -- Further Improvement: Consider adding the following properties:
                            Payment status: Add a field to indicate payment status (paid, pending, partial).
                            Transaction reference: Include a field for transaction reference numbers for online payments.

    */


    [Table("FeePayments")]
    public class FeePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeePaymentId { get; set; }
        public decimal TotalFee { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal Fine { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal TotalPaid { get; set; }
        public string ModeOfPayment { get; set; }
        public string PaymentModeDetails { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentDue { get; set; }



        public virtual List<FeeStructure> FeeStructures { get; set; } = new List<FeeStructure>();
        public virtual Student Student { get; set; }


    }
}
