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

        public virtual ICollection<Employee> refEmployees { get; set; } = new List<Employee>();
        public virtual ICollection<Classes> refClasses { get; set; } = new List<Classes>();
        public virtual ICollection<Exam> refExams { get; set; } = new List<Exam>();
        public virtual ICollection<Student> refStudents { get; set; } = new List<Student>();
    }
}
