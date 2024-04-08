using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("MonthlyPayment")]
    public class MonthlyPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonthlyPaymentId { get; set; }
        public int? StudentId { get; set; }
        public decimal TotalFeeAmount { get; set; }
        public decimal Waver { get; set; } = 0;
        public decimal PreviousDue { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountRemaining { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public Student? Student { get; set; }
        public IList<Fee> fees { get; set; }
        public IList<AcademicMonth> academicMonths { get; set; }
        public IList<PaymentMonth>? paymentMonths { get; set; }

        public IList<PaymentDetail>? PaymentDetails { get; set; }
        public IList<DueBalance>? dueBalances { get; set; }
    }
}
