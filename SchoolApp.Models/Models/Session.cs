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

    ## Need more analysis

    -- Should Purpose: Represents academic sessions (e.g., semesters, quarters) with duration, status, and status date. It's linked to subjects, classes, and sections.

    -- Further Improvement: Clarify how sessions relate to academic years and how they impact enrollments, exams, and other entities. Consider using separate tables for session start and end dates instead of a single StatusDate.
    */


    [Table("Sessions")]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionID { get; set; }
        public string SessionName { get; set; }

        public TimeSpan SessionDuration { get; set; }
        public string SessionStatus { get; set; }
        public DateTime StatusDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } 
        public virtual ICollection<Classes> Classes { get; set; } 
        public virtual ICollection<Section> Sections { get; set; } 
    }
}
