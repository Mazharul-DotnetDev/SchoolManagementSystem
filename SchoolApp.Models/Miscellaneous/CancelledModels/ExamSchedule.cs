using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    [Table("ExamSchedules")]
    public class ExamSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamScheduleId { get; set; }
        public DateTime ExamDate { get; set; }

        public DateTime ExamScheduleStartTime { get; set; }
        public DateTime ExamScheduleEndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int ObtainedMarks { get; set; }
        public int TotalMarks { get; set; }
        public string Result { get; set; }
        public string Remarks { get; set; }
        public string ExamScheduleStatus { get; set; }
        public DateTime ExamScheduleStatusDate { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
