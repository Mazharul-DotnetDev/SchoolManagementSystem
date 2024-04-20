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

        //The value of this property must be Unique (See in the SchoolDbContext.cs file)
        public int? SubjectCode { get; set; }

        public int? StandardId { get; set; }
        public virtual Standard? Standard { get; set; }
        public virtual ICollection<ExamSubject>? ExamSubjects { get; set; }
    }
}
