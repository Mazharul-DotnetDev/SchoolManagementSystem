using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Models
{

    /*
    -- Further Improvement: Consider adding a subject code or abbreviation for easier reference. 
    */


    [Table("Subjects")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
        public virtual ICollection<Classes> Classes { get; set; } 
        public virtual ICollection<Exam> Exams { get; set; } 
        public virtual ICollection<Student> Students { get; set; } 
    }
}
