﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Models
{
     
    /*
    -- Purpose: Tracks student and employee attendance details, including date, time, and presence status.


    */



    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime attendanceDate { get; set; }

        [Required(ErrorMessage = "Time is required")]
        [DataType(DataType.Time)]
        public DateTime attendanceTime { get; set; }
        public bool IsPresent { get; set; }

        public virtual ICollection<Student> refStudents { get; set; }
        public virtual ICollection<Employee> refEmployees { get; set; }



    }
}
