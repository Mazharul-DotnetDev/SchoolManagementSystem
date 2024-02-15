using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Models.Miscellaneous.CancelledModels
{

    [Table("Sessions")]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionID { get; set; }
        public string SessionName { get; set; }

        public TimeSpan SessionDuration { get; set; }
        public string SessionStatus { get; set; }
        public DateTime StatusDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
