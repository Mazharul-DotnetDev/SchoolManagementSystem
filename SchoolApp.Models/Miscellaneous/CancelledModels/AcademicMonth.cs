using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{


    [Table("AcademicMonths")]
    public class AcademicMonth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicMonthId { get; set; }
        public string AcademicMonthName { get; set; }


        public virtual ICollection<FeePayment> FeePayments { get; set; }


    }
}
