using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("Attendance")]
    public class Attendance
    {
        // Per day attendance record

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        public DateTime? WorkingDate { get; set; } = DateTime.Now;

        [Column(TypeName = "Time")]
        public TimeSpan? SignInTime { get; set; } 

        [Column(TypeName = "Time")]
        public TimeSpan? SignOutTime { get; set; } 
        public bool? IsPresent { get; set; }

        public IList<Staff>? Staffs { get; set; }
        public IList<Student>? Students { get; set; }


        // In this approach, the Attendance class constructor initializes the default values 

        //public Attendance()
        //{
        //    WorkingDate = DateTime.Now.Date;
        //    SignInTime = new TimeSpan(0, 0, 0);
        //    SignOutTime = new TimeSpan(0, 0, 0);
        //}

    }
}
