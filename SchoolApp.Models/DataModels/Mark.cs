using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{    

    [Table("Mark")]
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkId { get; set; }
  
        public int TotalMarks { get; set; } 
     
        public int PassMarks { get; set; } 
       
        public int ObtainedScore { get; set; } 

        public Grade Grade { get; set; } 

        public Pass PassStatus { get; set; } 
        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;
        public string? Feedback { get; set; }
      
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
     
        public int StudentId { get; set; }
        public Student? Student { get; set; }
       
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        

    }

    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public enum Pass
    {
        Passed, Failed, UnderConsideration, SpecialConsideration, Withdrawn,
        UnderJurisdiction
    }
}
