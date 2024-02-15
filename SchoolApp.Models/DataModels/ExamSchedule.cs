using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("ExamSchedule")]
    public class ExamSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamScheduleId { get; set; }
        public string? ExamScheduleName { get; set; }
        public int? ExamTypeId { get; set; }

        public IEnumerable<int>? SubjectId { get; set; } // NEED EXPLANATION
        public ExamType? ExamType { get; set; }

        public virtual ICollection<ExamSubject>? ExamSubjects { get; set; } = [];

        //Initialize the ExamSubjects collection in the constructor to avoid null reference exceptions when accessing it.
        //public ExamSchedule()
        //{
        //    ExamSubjects = new List<ExamSubject>();
        //}
    }
}
