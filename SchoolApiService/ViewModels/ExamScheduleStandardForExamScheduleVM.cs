using SchoolApp.Models.DataModels;

namespace SchoolApiService.ViewModels
{
    public class ExamScheduleStandardForExamScheduleVM
    {
        public string? StandardName { get; set; }

        public IEnumerable<ExamSubjectVM>? ExamSubjects { get; set; } = [];
    }
}
