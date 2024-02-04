﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Models
{

    /*
    -- Purpose: Represents an academic year (e.g., 2023-2024), used for grouping admissions, academic months, and potentially other year-specific data.

    -- Further Improvement: Include a CurrentYear property to easily identify the active academic year.
    */



    [Table("AcademicYears")]
    public class AcademicYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicYearId { get; set; }


        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Academic Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")]
        public DateTime Year { get; set; }



        public virtual ICollection<Admission> refAdmission { get; set; }


        public virtual ICollection<AcademicMonth> refAcademicMonth { get; set; }
    }
}
