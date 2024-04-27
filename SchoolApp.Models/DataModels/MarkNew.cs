using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("MarkNew")] // not migrated yet
    public class MarkNew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkId { get; set; }

        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;

        public int StaffId { get; set; }
        public Staff? Staff { get; set; }              

        
        public int ExamTypeId { get; set; }
        public ExamType? ExamType { get; set; }

        public int ExamScheduleId { get; set; }
        public ExamSchedule? ExamSchedule { get; set; }

        public int ExamScheduleStandardId { get; set; }
        public ExamScheduleStandard? ExamScheduleStandard { get; set; }


        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }


        public int ExamSubjectId { get; set; }
        public ExamSubject? ExamSubject { get; set; }

        public int TotalMarks { get; set; }
        public int PassMarks { get; set; }

        public virtual ICollection<Student>? Students { get; set; } = [];


        public int ObtainedScore { get; set; }

        public Grade? Grade { get; set; }

        public Pass? PassStatus { get; set; }
        
        public string? Feedback { get; set; }                     

    }

    public enum Grades
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public enum PassStatus
    {
        Passed, Failed, UnderConsideration, SpecialConsideration, Withdrawn,
        UnderJurisdiction
    }


}
