using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("Fee")]
    public class Fee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeeId { get; set; }
        public int FeeTypeId { get; set; }
        public int StandardId { get; set; }
        public Frequency PaymentFrequency { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
        public Standard? standard { get; set; }
        public FeeType? feeType { get; set; }
        public MonthlyPayment? monthlyPayment { get; set; }
        public OthersPayment? othersPayment { get; set; }

    }

    public enum Frequency
    {
        Monthly,
        Yearly,
        Quarterly,
        Semesterly,
        Biannually,
        Custom
    }

}
