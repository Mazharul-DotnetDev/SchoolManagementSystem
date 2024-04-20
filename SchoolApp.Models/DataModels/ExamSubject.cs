using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("ExamSubject")]
    public class ExamSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamSubjectId { get; set; }
        public int ExamScheduleStandardId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public DateTime? ExamDate { get; set; } = DateTime.Now;
        public TimeSpan? ExamStartTime { get; set; }
        public TimeSpan? ExamEndTime { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ExamType? ExamType { get; set; }
        public virtual ExamScheduleStandard? ExamScheduleStandard { get; set; }
    }
}
