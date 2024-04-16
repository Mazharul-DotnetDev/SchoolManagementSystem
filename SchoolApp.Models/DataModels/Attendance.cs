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

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int AttendanceId { get; set; }       
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public AttendanceType Type { get; set; } = AttendanceType.Student;
        [Required]
        public int AttendanceIdentificationNumber { get; set; } = 111;
        public string? Description { get; set; }
        public bool IsPresent { get; set; } = true;          
    }

    public enum AttendanceType
    {
        Student,
        Staff
    }
}
