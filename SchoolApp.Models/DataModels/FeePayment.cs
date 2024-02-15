using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("FeePayment")]
    public class FeePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeePaymentId { get; set; }
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal AmountAfterDiscount { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountRemaining { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public Student? Student { get; set; }
        public IList<FeeStructure>? FeeStructures { get; set; }
        public IList<FeePaymentDetail>? FeePaymentDetails { get; set; }

    }
}
