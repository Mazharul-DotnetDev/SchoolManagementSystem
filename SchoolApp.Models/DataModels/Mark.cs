using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    //The purpose of creating This table is to entry individual marks of an individual student. [And then, all of the marks of every individuals will be added to MarksEntry class.] So, the values of StudentId and SubjectId must be given.


    [Table("Mark")]
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkId { get; set; }
        public int? ExamPaperScore { get; set; }       
        public int? PassMarks { get; set; }        
        public int? ObtainedScore { get; set; }
        public Grade? Grade { get; set; }
        public Pass? PassStatus { get; set; }      
        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;
        public string? Feedback { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        // Feature: Soft Delete Approach
        //public bool IsDeleted { get; set; }

    }

    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public enum Pass
    {
        Passed, Failed, UnderConsideration, SpecialConsideration, Withdrawn,
        UnderJurisdiction
    }
}
