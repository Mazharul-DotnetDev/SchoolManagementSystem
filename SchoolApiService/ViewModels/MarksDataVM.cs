using SchoolApp.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace SchoolApiService.ViewModels
{
    public class MarksDataVM
    {
        public int MarkEntryId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
       
        public float? Mark { get; set; }
        //public PassStatus Status { get; set; }


    }
}
