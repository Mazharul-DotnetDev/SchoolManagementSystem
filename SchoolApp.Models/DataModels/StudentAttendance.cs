using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    //[Table("StudentAttendance")]
    public class StudentAttendance : Attendance
    {
        public int StudentId { get; set; } // Foreign key
        public Student? Student { get; set; } // Navigation property


        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        //public int StudentAttendanceId { get; set; }
        //[Column(TypeName = "date")]  
        //[DefaultValue(typeof(DateOnly), "GETUTCDATE()")]
        //public DateOnly WorkingDate { get; set; }
        //public bool? IsPresent { get; set; } = true;
        //public ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}
