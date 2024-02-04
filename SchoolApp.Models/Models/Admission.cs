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
    -- Purpose: Represents the admission details of a student, including admission date, section, and enrollment information.

    -- Further Improvement: To Clarify the meaning of Status and StatusDate with additional properties or enums.
    */




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
        public virtual Student refStudent { get; set; }
        public virtual AcademicYear refAcademicYear { get; set; }

        // this is rectified, due to recursion issue, to Enrollment

        //public virtual Classes refClass { get; set; }

        //public string ClassName { get { return refStudent.Classses.ClassName; } }


        public int EnrollmentId { get; set; }
        public virtual Enrollment refEnrollment { get; set; }
    }
}
