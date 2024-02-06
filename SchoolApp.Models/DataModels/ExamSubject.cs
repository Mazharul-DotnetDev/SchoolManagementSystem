using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    public class ExamSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamSubjectId { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;

        public int SubjectId { get; set; }      
        public Subject Subject { get; set; }
      
    }
}
