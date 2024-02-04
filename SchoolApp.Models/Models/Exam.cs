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
    -- Further Improvement: Define the possible values for ExamStatus with an enum for better data integrity. 
    */


    [Table("Exams")]
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamID { get; set; }

        public int PassingMarks { get; set; }
        public string ExamStatus { get; set; }
        public DateTime ExamStatusDate { get; set; }

        public virtual ICollection<Classes> Classes { get; set; } 
        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; } 
        public virtual ICollection<Subject> Subjects { get; set; } 


    }
}
