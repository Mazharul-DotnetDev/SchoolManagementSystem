using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolApp.Models.DataModels
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        //Add [Index(IsUnique = true)] using FluentAPI
        public int SubjectCode { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }       
    }
}
