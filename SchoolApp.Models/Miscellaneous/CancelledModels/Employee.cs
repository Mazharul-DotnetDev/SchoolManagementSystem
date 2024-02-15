using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{


    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeAdress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmployeeDOB { get; set; }

        public string? ImagePath { get; set; }

        public int EmployeeTypeId { get; set; }

        public virtual EmployeeType? EmployeeType { get; set; }
    }
}
