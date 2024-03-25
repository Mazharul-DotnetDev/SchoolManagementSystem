using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("MarkEntry")]
    public class MarkEntry
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int MarkEntryId { get; set; }
        //public DateTime? MarkEntryDate { get; set; } = DateTime.Now;
        //public int StaffId { get; set; }                  
        //public Staff? Staff { get; set; }

        ////public int SubjectId { get; set; }
        ////public Subject? Subject { get; set; }

        //public IList<Mark>? Marks { get; set; }

       
    }
}
