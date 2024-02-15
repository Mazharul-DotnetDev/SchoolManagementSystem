using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{


    [Table("AcademicYears")]
    public class AcademicYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicYearId { get; set; }


        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Academic Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public DateTime Year { get; set; }



        public virtual ICollection<Admission> Admissions { get; set; }


        public virtual ICollection<AcademicMonth> AcademicMonths { get; set; }
    }
}
