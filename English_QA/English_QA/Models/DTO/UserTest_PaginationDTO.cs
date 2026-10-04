namespace English_QA.Models.DTO
{
    public class UserTest_PaginationDTO
    {
        public long Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string QuestionCategory { get; set; } = string.Empty;
        public string AnswerType { get; set; } = string.Empty;
        public string MultipleAnswer01 { get; set; } = string.Empty;
        public string MultipleAnswer02 { get; set; } = string.Empty;
        public string MultipleAnswer03 { get; set; } = string.Empty;
        public string MultipleAnswer04 { get; set; } = string.Empty;
        public long UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public long TestCount { get; set; }
    }
}
