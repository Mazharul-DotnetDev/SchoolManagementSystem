using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("StaffExperience")]
    public class StaffExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffExperienceId { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public DateTime? LeavingDate { get; set; } = DateTime.Now;
        public string? Responsibilities { get; set; }
        public string? Achievements { get; set; }
        public TimeSpan? ServiceDuration => LeavingDate.HasValue
                                      ? LeavingDate.Value - JoiningDate
                                      : DateTime.Now - JoiningDate;
        

    }
}
