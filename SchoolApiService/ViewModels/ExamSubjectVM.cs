namespace SchoolApiService.ViewModels
{
    public class ExamSubjectVM
    {
        public string? ExamTypeName { get; set; }
        public string? SubjectName { get; set; }
        public int? SubjectCode { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? ExamStartTime { get; set; }
        public DateTime? ExamEndTime { get; set; }
    }
}
