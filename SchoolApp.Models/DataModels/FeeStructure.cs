using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    [Table("FeeStructure")]
    public class FeeStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeeStructureId { get; set; }
        public int FeeTypeId { get; set; }
        public string? TypeName { get; set; }
        public int? StandardId { get; set; }
        public string? StandardName { get; set; }
        public bool? Monthly { get; set; }
        public bool? Yearly { get; set; }
        public decimal FeeAmount { get; set; }

        [JsonIgnore]
        public FeePayment? FeePayment { get; set; }
        public FeeType? FeeType { get; set; }
        public Standard? Standard { get; set; }

    }
}
