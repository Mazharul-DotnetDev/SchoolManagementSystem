namespace SchoolApiService.ViewModels
{
    public class CreateExamSubjectWithScheduleVM
    {
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public DateTime? ExamDate { get; set; }
        public string? ExamStartTime { get; set; }
        public string? ExamEndTime { get; set; }
    }
}
