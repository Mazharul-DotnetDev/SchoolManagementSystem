using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

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

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
