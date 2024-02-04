using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Models
{
    /*
    -- Purpose: Used for tracking fee payments or other time-bound activities. Multiple fee payments can be associated with an academic month.

    -- Further Improvement: Consider adding a StartDate and EndDate property for each month to clearly define its timeframe.
    */


    [Table("AcademicMonths")]
    public class AcademicMonth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicMonthId { get; set; }
        public string AcademicMonthName { get; set; }


        public virtual ICollection<FeePayment> refFeePayment { get; set; }


    }
}
