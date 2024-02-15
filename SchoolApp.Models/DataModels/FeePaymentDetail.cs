using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("FeePaymentDetail")]
    public class FeePaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeePaymentDetailId { get; set; }
        public int FeePaymentId { get; set; }
        public string FeeTypeName { get; set; }
        public decimal FeeAmount { get; set; }

        //public virtual FeeType? FeeType { get; set; }
    }
}
