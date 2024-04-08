using SchoolApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }

        [Required]
        public int UniqueStaffAttendanceNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? TemporaryAddress { get; set; }      
        public string? PermanentAddress { get; set; }
        public string? ContactNumber1 { get; set; }
        [EmailAddress]
        public string? Email { get; set; }       
        public string? ImagePath { get; set; }
        public string? Qualifications { get; set; }
        public DateTime? JoiningDate { get; set; }
        public Designation? Designation { get; set; }
        public string? BankAccountName { get; set; }
        public int? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? Status { get; set; }


        public int? DepartmentId { get; set; }

        
        public  Department? Department { get; set; }

        public int? StaffSalaryId { get; set; }

        
        public StaffSalary? StaffSalary { get; set; }

        public IList<StaffExperience>? StaffExperiences { get; set; }


        //// Constructor to initialize UniqueAttendanceId
        //public Staff()
        //{
        //    UniqueStaffAttendanceId = "STF-" + GenerateFixedNumbers(); // Generate fixed numbers
        //}

        //private string GenerateFixedNumbers()
        //{
        //    // You can generate a random or sequential number here
        //    // For simplicity, let's generate a sequential number for demonstration
        //    return (2000 + StaffId).ToString(); // Example: STF-2001, STF-2002, etc.
        //}
    }


    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum Designation
    {
        // School Leadership
        Superintendent,
        Headmaster,
        Headmistress,
        AssistantPrincipal,
        Dean,
        Director,

        // Academic Staff
        DepartmentChair,
        Professor,
        Instructor,
        Lecturer,
        TeachingAssistant,
        SpecialEducationTeacher,
        SubstituteTeacher,

        // Support Staff
        Counselor,
        Librarian,
        MediaSpecialist,
        LabTechnician,
        ITSpecialist,
        BusDriver,
        LunchAide,
        Custodian,

        // Administrative Staff
        Registrar,
        AdmissionsOfficer,
        BusinessManager,
        DevelopmentOfficer,
        HumanResourcesManager,
        Receptionist,

        // Other
        Coach,
        SecurityGuard,
        MaintenanceWorker,
        FoodServiceWorker,
        Other
    }

}
