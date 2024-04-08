using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("OthersPayment")]
    public class OthersPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OthersPaymentId { get; set; }
        public int? StudentId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountRemaining { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public Student? Student { get; set; }
        public IList<Fee>? fees { get; set; }
        public IList<OtherPaymentDetail>? otherPaymentDetails { get; set; }

    }
}
