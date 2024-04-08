using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("OtherPaymentDetail")]
    public class OtherPaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentDetailId { get; set; }
        public int OthersPaymentId { get; set; }
        public string FeeName { get; set; }
        public decimal FeeAmount { get; set; }

    }
}
