using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("ExamType")]
    public class ExamType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamTypeId { get; set; }
        [Required]
        public string? ExamTypeName { get; set; }
        public virtual ICollection<ExamSubject>? ExamSubjects { get; set; }
    }

    //public enum ExamTypeName
    //{
    //    ClassTest,
    //    UnitTest,
    //    Midterm,
    //    FinalExam,
    //    MonthlyExam,
    //    WeeklyExam,
    //    PerformanceEvaluation,
    //    LabPractical,
    //    Final,
    //    Quiz,
    //    Assignment,
    //    Project,
    //    Oral,
    //    Practical,
    //    Theory,
    //    Presentation,
    //    Test,
    //    Homework,
    //    Lab,
    //    Fieldwork,       
    //    ReviewExam,
    //    ExitExam,
    //    PlacementExam,
    //    DiagnosticExam,
    //    Mock,
    //    ProgressExam,
    //    EvaluationExam,
    //    ObservationExam,
    //    PortfolioExam,
    //    Viva,
    //    EntranceExam,
    //    ScholarshipExam,
    //    Other
    //}
}
