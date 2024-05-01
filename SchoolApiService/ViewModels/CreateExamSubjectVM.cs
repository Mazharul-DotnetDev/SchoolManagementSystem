namespace SchoolApiService.ViewModels
{
    public class CreateExamSubjectVM
    {
        public int ExamScheduleStandardId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTypeId { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
    }
}
