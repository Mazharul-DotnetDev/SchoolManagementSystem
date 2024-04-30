using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolApp.Models.DataModels
{
    [Table("MarkEntry")] // not migrated yet
    public class MarkEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkEntryId { get; set; }

        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;

        public int StaffId { get; set; }
        public Staff? Staff { get; set; }


        // 1st Semester, 2nd Semester
        public int ExamScheduleId { get; set; }
        public ExamSchedule? ExamSchedule { get; set; }



        // Oral, Writen, MCQ
        public int ExamTypeId { get; set; }
        public ExamType? ExamType { get; set; }

        

        // Class 1, Class 2
        //public int ExamScheduleStandardId { get; set; }
        //public ExamScheduleStandard? ExamScheduleStandard { get; set; }


        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }


        public int StandardId { get; set; }
        public Standard? Standard { get; set; }


        // Bengali, 
        //public int ExamSubjectId { get; set; }
        //public ExamSubject? ExamSubject { get; set; }

        public int? TotalMarks { get; set; }
        public int? PassMarks { get; set; }


        //public virtual ICollection<Student>? Students { get; set; } = [];


        public virtual ICollection<StudentMarksDetails> StudentMarksDetails { get; set; } = [];

    }

   

}
