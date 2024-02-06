using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public int AdmissionNo { get; set; }
        public int EnrollmentNo { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentDOB { get; set; }
        private int _studentCurrentAge;

        // Expose the age through a public property
        public int StudentCurrentAge
        {
            get
            {
                // Calculate the age based on StudentDOB
                TimeSpan span = DateTime.Today - StudentDOB;
                _studentCurrentAge = (int)(span.TotalDays / 365.25);
                return _studentCurrentAge;
            }
            private set { _studentCurrentAge = value; } // Make the setter private
        }

        public GenderList StudentGender { get; set; }
        public string StudentReligion { get; set; }
        public string StudentBloodGroup { get; set; }
        public string StudentNationality { get; set; }
        public int StudentNIDNumber { get; set; }
        public string StudentContactNumber1 { get; set; }
        public string StudentContactNumber2 { get; set; }
        [EmailAddress]
        public string StudentEamil { get; set; }
        public string PermanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string FatherName { get; set; }
        public int FatherNID { get; set; }
        public string FatherContactNumber { get; set; }
        public string MotherName { get; set; }
        public int MotherNID { get; set; }
        public string MotherContactNumber { get; set; }
        public string? LocalGuardianName { get; set; }
        public string? LocalGuardianContactNumber { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }


    }

    public enum GenderList
    {
        Male,
        Female,
        Other
    }

    
}
