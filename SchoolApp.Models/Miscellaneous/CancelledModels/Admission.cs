using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    [Table("Admissions")]
    public class Admission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdmissionId { get; set; }
        public DateTime AdmissionDate { get; set; }

        public string Section { get; set; }
        public DateTime AdmissionStatusDate { get; set; }
        public string AdmissionStatus { get; set; }
        public string AdmissionUpdatedBy { get; set; }
        public DateTime AdmissionUpdatedOn { get; set; }

        public int StudentId { get; set; } // Add this property
        public virtual Student Student { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        // this is rectified, due to recursion issue, to Enrollment
        //public virtual Classes refClass { get; set; }

        public int EnrollmentId { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
