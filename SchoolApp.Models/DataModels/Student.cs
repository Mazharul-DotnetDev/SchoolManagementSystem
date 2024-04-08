using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SchoolApp.Models.DataModels
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Enrollment number is required")]
        public int? AdmissionNo { get; set; }

        [Required(ErrorMessage = "Enrollment number is required")]
        public int EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Unique Student Attendance Number is required")]
        //[Index (IsUnique = true)]
        public int UniqueStudentAttendanceNumber { get; set; }

        public string? StudentName { get; set; }

        public DateTime StudentDOB { get; set; }

        public GenderList? StudentGender { get; set; }

        public string? StudentReligion { get; set; }

        public string? StudentBloodGroup { get; set; }

        public string? StudentNationality { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "NID number should contain only numeric characters")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "NID number should be 17 digits")]
        public string? StudentNIDNumber { get; set; }

        public string? StudentContactNumber1 { get; set; }

        public string? StudentContactNumber2 { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? StudentEmail { get; set; }

        public string? PermanentAddress { get; set; }

        public string? TemporaryAddress { get; set; }

        public string? FatherName { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Father's NID number should contain only numeric characters")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Father's NID number should be 17 digits")]
        public string? FatherNID { get; set; }

        public string? FatherContactNumber { get; set; }

        public string? MotherName { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Mother's NID number should contain only numeric characters")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Mother's NID number should be 17 digits")]
        public string? MotherNID { get; set; }

        public string? MotherContactNumber { get; set; }

        public string? LocalGuardianName { get; set; }

        public string? LocalGuardianContactNumber { get; set; }

        [Required(ErrorMessage = "Standard is required")]
        public int? StandardId { get; set; }

        public Standard? Standard { get; set; }


        //// Constructor to initialize UniqueAttendanceId
        //public Student()
        //{
        //    UniqueStudentAttendanceId = "STD-" + GenerateFixedNumbers(); // Generate fixed numbers
        //}

        //private string GenerateFixedNumbers()
        //{
        //    // You can generate a random or sequential number here
        //    // For simplicity, let's generate a sequential number for demonstration
        //    return "STD-" + (1000 + StudentId).ToString(); // Example: STD-1001, STD-1002, etc.
        //}
    }

    public enum GenderList
    {
        Male,
        Female,
        Other
    }
}
