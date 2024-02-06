using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required]
        public DepartmentName DepartmentName { get; set; }
        public int NumberOfStaff { get; set; } = 0;

        public IList<Staff> Staffs { get; set; }
    }

    public enum DepartmentName
    {
        // Academic Departments
        Science,
        Mathematics,
        English,
        History,
        Language,
        SocialStudies,
        Art,
        Music,
        PhysicalEducation,

        // Administrative Departments
        Admissions,
        Registrar,
        Finance,
        HumanResources,
        Development,
        InformationTechnology,

        // Other Departments
        SpecialEducation,
        Counseling,
        Library,
        Athletics,
        Maintenance,
        FoodService,
        Other
    }

}
