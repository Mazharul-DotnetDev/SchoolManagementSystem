using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SchoolApp.Models.Models
{
    /*
    -- Purpose: Represents different classes offered, including name, division, status, and associated students, sections, subjects, resources, and enrollments.

    -- Further Improvement: Define the possible values for ClassStutus with an enum or separate table for better data integrity.
    */



    [Table("classes")]
    public class Classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Division { get; set; }
        public string ClassStutus { get; set; }
        public DateTime ClassStutusDateTime { get; set; }

        public virtual ICollection<Student> refStudents { get; set; } = new List<Student>();
        public virtual ICollection<Section> refSections { get; set; } = new List<Section>();
        public virtual ICollection<Subject> refSubjects { get; set; } = new List<Subject>();
        public virtual ICollection<Resource> refResources { get; set; } = new List<Resource>();



        public virtual ICollection<Enrollment> refEnrollments { get; set; } = new List<Enrollment>();
    }
}
