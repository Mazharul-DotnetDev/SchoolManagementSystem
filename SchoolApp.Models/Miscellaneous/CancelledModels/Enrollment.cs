using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{
    /*
     * -- to resolve cyclic recursion between Student, Class, and Admission, linking students to their enrolled classes and corresponding admissions.
     * 
     * 
    To address the "Introducing FOREIGN KEY constraint may cause cycles or multiple cascade paths" issue,
    an intermediary table 'Enrollment' has been introduced. This table acts as a junction to break
    cyclic dependencies and facilitate relationships between multiple classes.

    This solution avoids cascading referential actions that could lead to conflicts in the database schema.
    The 'Enrollment' table serves as a link to establish connections between entities, providing a clean
    and manageable solution to the complex relationships in the database.

    Please note that 'Enrollment' is not part of the original database planning but has been strategically added to enhance the structure and ensure smooth migrations without encountering cyclic dependencies.

    Collaborators should be aware of the purpose of 'Enrollment' and carefully manage its relationships
    when working with related classes to maintain data integrity.

    */


    [Table("Enrollments")]
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int ClassId { get; set; }
        public virtual Classes Classes { get; set; }

        public int AdmissionId { get; set; }
        public virtual Admission Admission { get; set; }
    }
}
