using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        public int AcademicYearId { get; set; }
        public required string Name { get; set; }


    }
}
