using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("PaymentDetail")]
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentDetailId { get; set; }
        public int MonthlyPaymentId { get; set; }
        public string FeeName { get; set; }
        public decimal FeeAmount { get; set; }

    }
}
