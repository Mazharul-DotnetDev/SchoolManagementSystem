using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("StaffSalary")]
    public class StaffSalary
    {
        // Per individual Staff's salary prototype

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffSalaryId { get; set; }
        public decimal? BasicSalary { get; set; }
        public decimal? FestivalBonus { get; set; }
        public decimal? Allowance { get; set; }
        public decimal? MedicalAllowance { get; set; }
        public decimal? HousingAllowance { get; set; }        
        public decimal? TransportationAllowance { get; set; }
        public decimal? SavingFund { get; set; } = 0;
        public decimal? Taxes { get; set; } = 0;
        // See the SchoolDbContext.cs file 
        public decimal? NetSalary { get; set; } // Add NetSalary property to be stored in the database; Related to CalculateNetSalary() method

        // Method to calculate net salary
        public void CalculateNetSalary()
        {
            NetSalary = BasicSalary + FestivalBonus + Allowance + MedicalAllowance + HousingAllowance + TransportationAllowance - SavingFund - Taxes;
        }


        //public string SalaryBreakdown => $"Basic Salary: {BasicSalary}, " +
        //                         $"Festival Bonus: {FestivalBonus}, " +
        //                         $"Allowance: {Allowance}, " +
        //                         $"Medical Allowance: {MedicalAllowance}, " +


        //                         $"Housing Allowance: {HousingAllowance}, " +
        //                         $"Transportation Allowance: {TransportationAllowance}, " +

        //                         $"Saving Fund: {SavingFund}, " +
        //                         $"Taxes: {Taxes}, " +
        //                         $"Net Salary: {NetSalary}";



    }
}
