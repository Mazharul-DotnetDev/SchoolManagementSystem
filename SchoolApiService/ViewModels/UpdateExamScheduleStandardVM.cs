namespace SchoolApiService.ViewModels
{
    public class UpdateExamScheduleStandardVM
    {
        public int ExamScheduleStandardId { get; set; }
        public int ExamScheduleId { get; set; }
        public int StandardId { get; set; }
        public IEnumerable<CreateExamSubjectWithScheduleVM>? ExamSubjects { get; set; }
    }
}
