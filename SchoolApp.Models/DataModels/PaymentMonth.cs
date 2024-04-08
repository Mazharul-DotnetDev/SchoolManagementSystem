using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("PaymentMonth")]
    public class PaymentMonth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentMonthId { get; set; }
        public int MonthlyPaymentId { get; set; }
        public string MonthName { get; set; }
    }
}
