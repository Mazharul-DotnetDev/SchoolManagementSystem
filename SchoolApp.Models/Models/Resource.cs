using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Models
{

    /*
    -- Purpose: Represents educational resources (e.g., textbooks, notes, videos) associated with classes or subjects.

    -- Further Improvement: Add information about the resource type (book, video, etc.) and a link to the resource file or location.
    */


    [Table("Resources")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public bool IsAvailable { get; set; }

    }
}
