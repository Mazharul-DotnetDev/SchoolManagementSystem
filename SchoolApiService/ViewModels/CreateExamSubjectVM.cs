namespace SchoolApiService.ViewModels
{
    public class CreateExamSubjectVM
    {
        public int ExamScheduleStandardId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public DateTime? ExamDate { get; set; }
        public TimeSpan? ExamStartTime { get; set; }
        public TimeSpan? ExamEndTime { get; set; }
    }
}
