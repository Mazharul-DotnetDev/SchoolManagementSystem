using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.DataModels
{
    // Class table, renamed for avoiding built-in keyword clash
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }              
        public string ClassRoomCapacity { get; set; }

    }
}
