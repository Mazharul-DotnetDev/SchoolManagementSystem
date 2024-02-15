using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [Required]
        public DepartmentName? DepartmentName { get; set; }
        public int? NumberOfStaff { get; set; } = 0;

        public IList<Staff>? Staffs { get; set; }
    }

    public enum DepartmentName
    {
        // Academic Departments
        [Display(Name = "Science")]
        Science,

        [Display(Name = "Mathematics")]
        Mathematics,

        [Display(Name = "English")]
        English,

        [Display(Name = "History")]
        History,

        [Display(Name = "Language")]
        Language,

        [Display(Name = "Social Studies")]
        SocialStudies,

        [Display(Name = "Art")]
        Art,

        [Display(Name = "Music")]
        Music,

        [Display(Name = "Physical Education")]
        PhysicalEducation,

        // Administrative Departments
        [Display(Name = "Admissions")]
        Admissions,

        [Display(Name = "Registrar")]
        Registrar,

        [Display(Name = "Finance")]
        Finance,

        [Display(Name = "Human Resources")]
        HumanResources,

        [Display(Name = "Development")]
        Development,

        [Display(Name = "Information Technology")]
        InformationTechnology,

        // Other Departments
        [Display(Name = "Special Education")]
        SpecialEducation,

        [Display(Name = "Counseling")]
        Counseling,

        [Display(Name = "Library")]
        Library,

        [Display(Name = "Athletics")]
        Athletics,

        [Display(Name = "Maintenance")]
        Maintenance,

        [Display(Name = "Food Service")]
        FoodService,

        [Display(Name = "Other")]
        Other
    }

}
