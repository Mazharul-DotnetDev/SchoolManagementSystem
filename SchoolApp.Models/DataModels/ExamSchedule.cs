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

        [Required]
        public string? ExamScheduleName { get; set; }

        public virtual ICollection<ExamScheduleStandard>? ExamScheduleStandards { get; set; } = [];
    }
}
