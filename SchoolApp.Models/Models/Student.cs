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
        public virtual ICollection<Enrollment> refEnrollments { get; set; } = new List<Enrollment>();


        public virtual ICollection<Subject> refSubjects { get; set; } = new List<Subject>();

        public virtual ICollection<ExamSchedule> refExamSchedules { get; set; } = new List<ExamSchedule>();
        public virtual ICollection<FeePayment> refFeePayments { get; set; } = new List<FeePayment>();
        public virtual ICollection<Resource> refResources { get; set; } = new List<Resource>();
        public virtual ICollection<Attendance> refAttendances { get; set; } = new List<Attendance>();
    }
}
