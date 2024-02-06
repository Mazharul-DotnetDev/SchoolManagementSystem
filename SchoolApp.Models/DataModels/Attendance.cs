using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    public class Attendance
    {
        // Per day attendance record

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        public DateTime WorkingDate { get; set; } = DateTime.Now;
        public DateTime SignInTime { get; set; } = DateTime.Now;
        public DateTime SignOutTime { get; set; } = DateTime.Now;
        public bool? IsPresent { get; set; }

        public IList<Staff> Staffs { get; set; }
        public IList<Student> Students { get; set; }
    }
}
