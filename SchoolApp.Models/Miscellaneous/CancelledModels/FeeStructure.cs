using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    /*
    -- Purpose:
    Real-world examples:
    Tuition fee for Class 10A: 
    FeeStructureName = "Tuition Fee - Class 10A", Fee = $1000, refClasses = Class 10A, refFeeType = Tuition Fee.
    Activity fee for all classes: 
    FeeStructureName = "Annual Sports Activity Fee", Fee = $50, refClasses = All Classes, refFeeType = Activity Fee.

    -- Further Improvement: To Consider adding Conditional fees- Allow for conditional fee structures based on student criteria (e.g., scholarships, discounts).
    */


    [Table("FeeStructures")]
    public class FeeStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FeeStructureId { get; set; }
        public string FeeStructureName { get; set; }
        public decimal AmountOfFee { get; set; }
        public virtual Classes Classes { get; set; }
        public virtual FeeType FeeType { get; set; }

    }
}
