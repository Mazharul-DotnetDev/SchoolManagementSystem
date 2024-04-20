namespace SchoolApiService.ViewModels
{
    public class CreateExamScheduleStandardVM
    {
        public int ExamScheduleId { get; set; }
        public int StandardId { get; set; }
        public IEnumerable<CreateExamSubjectWithScheduleVM>? ExamSubjects { get; set; }
    }
}
