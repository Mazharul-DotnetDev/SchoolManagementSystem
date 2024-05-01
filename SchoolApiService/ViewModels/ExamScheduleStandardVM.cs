namespace SchoolApiService.ViewModels
{
    public class ExamScheduleStandardVM
    {
        public int ExamScheduleStandardId { get; set; }
        public int? ExamScheduleId { get; set; }
        public int? StandardId { get; set; }
        public string? StandardName { get; set; }
        public string? ExamScheduleName { get; set; }
        public IEnumerable<ExamSubjectVM>? ExamSubjects { get; set; } = [];
    }
}
