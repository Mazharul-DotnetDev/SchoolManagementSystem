using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolApp.Models.DataModels
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }       
        public int? SubjectCode { get; set; } //must be Unique. There are lot of same subjects in different Standard/Class. So, to make it distinguish, this property is created.
        public int? StandardId { get; set; }
        public virtual Standard? Standard { get; set; }
        public virtual ICollection<ExamSubject>? ExamSubjects { get; set; }
    }
}
