namespace SchoolApiService.ViewModels
{
    public class ExamScheduleVM
    {
        public int ExamScheduleId { get; set; }
        public string? ExamScheduleName { get; set; }
        public IEnumerable<ExamScheduleStandardForExamScheduleVM>? ExamScheduleStandards { get; set; } = [];
    }
}
