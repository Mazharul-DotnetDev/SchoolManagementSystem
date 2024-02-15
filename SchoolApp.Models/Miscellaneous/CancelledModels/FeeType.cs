using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    /*
    -- Purpose: Categorizes different types of fees (e.g., tuition, activity fees, exam fees) with associated status and status date.

    -- Further Improvement: Define the possible values for FeeTypeStatus with an enum for better data integrity. Consider adding a description for each fee type.
    */


    [Table("FeeTypes")]
    public class FeeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeetypeId { get; set; }
        public string FeeTypeName { get; set; }
        public string FeeTypeStatus { get; set; }
        public DateTime FeeTypeStatusDate { get; set; }

    }
}
