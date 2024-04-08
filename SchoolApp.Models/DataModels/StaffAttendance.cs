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
    //[Table("StaffAttendance")]
    public class StaffAttendance : Attendance
    {      
        public int StaffId { get; set; } // Foreign key
        public Staff? Staff { get; set; } // Navigation property


        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int StaffAttendanceId { get; set; }
        //[Column(TypeName = "date")]  
        //[DefaultValue(typeof(DateOnly), "GETUTCDATE()")]
        //public DateOnly WorkingDate { get; set; } 
        //public bool? IsPresent { get; set; } = true;
        //public ICollection<Staff>? Staffs { get; set; } = new List<Staff>();
    }
}
