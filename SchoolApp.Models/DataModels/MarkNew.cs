using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        // Bengali, 
        //public int ExamSubjectId { get; set; }
        //public ExamSubject? ExamSubject { get; set; }

        public int TotalMarks { get; set; }
        public int PassMarks { get; set; }

        public virtual ICollection<Student>? Students { get; set; } = [];


        public int ObtainedScore { get; set; }

        public GradesSystem? Grade { get; set; } = GradesSystem.A;

        public PassFailStatus? PassStatus { get; set; } = PassFailStatus.Passed;
        
        public string? Feedback { get; set; }                     

    }

    public enum GradesSystem
    {
        A, B, C, D, E, F, NotApplicable
    }

    public enum PassFailStatus
    {
        Passed, Failed, UnderConsideration, SpecialConsideration, Withdrawn, UnderJurisdiction
    }


    #region CollectionSeedData
    /*
   update Student
Set [MarkEntryId] = 1
where StudentId =1
go
update Student
Set [MarkEntryId] = 1
where StudentId =2
go
update Student
Set [MarkEntryId] = 1
where StudentId =3
go
update Student
Set [MarkEntryId] = 2
where StudentId =4
go
update Student
Set [MarkEntryId] = 2
where StudentId =5
go
update Student
Set [MarkEntryId] = 2
where StudentId =6

*/ 
    #endregion

}
