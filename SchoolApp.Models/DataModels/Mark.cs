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
        [Required]
        public int TotalMarks { get; set; } 
        [Required]
        public int PassMarks { get; set; } 
        [Required]
        public int ObtainedScore { get; set; } 
        [Required]
        public Grade Grade { get; set; } 
        [Required]
        public Pass PassStatus { get; set; } 
        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;
        public string? Feedback { get; set; }
        [Required]
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        // Feature: Soft Delete Approach
        //public bool IsDeleted { get; set; }

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
