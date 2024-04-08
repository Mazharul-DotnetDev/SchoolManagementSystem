using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("AcademicMonth")]
    public class AcademicMonth
    {
        [Key]
        public int MonthId { get; set; }
        public String? MonthName { get; set; }
        public MonthlyPayment? monthlyPayment { get; set; }

    }
}
