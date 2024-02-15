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
    -- Further Improvement: Consider using unique identifiers like student ID or enrollment number. Include emergency contact information for parents and their relationship to the student. 
    */

    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int RollNumber { get; set; }
        public DateTime StudentDOB { get; set; }
        public string StudentGender { get; set; }

        public string StudentAddress { get; set; }
        public string StudentStatus { get; set; }

        //public DateTime EnrollmentDate { get; set; }  

        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }

        // the following Navigation reference is rectified, due to recursion issue, to Enrollment entity
        //public virtual Classes Classses { get; set; }
        public virtual Section Section { get; set; }
        // the following Navigation reference is rectified, due to recursion issue, to Enrollment entity
        //public int AdmissionId { get; set; }
        //public virtual Admission refAdmission { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
        public virtual ICollection<FeePayment> FeePayments { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
