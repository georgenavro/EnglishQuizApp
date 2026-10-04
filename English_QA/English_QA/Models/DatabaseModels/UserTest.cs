namespace English_QA.Models.DatabaseModels
{
    public class UserTest
    {
        public long Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string MultipleAnswer01 { get; set; } = string.Empty;
        public string MultipleAnswer02 { get; set; } = string.Empty;
        public string MultipleAnswer03 { get; set; } = string.Empty;
        public string MultipleAnswer04 { get; set; } = string.Empty;
        public long TestCount { get; set; }
        public long UserID { get; set; }
        public long questionCategoryID { get; set; }
        public long AnswerTypeID { get; set; }
        public Users? User { get; set; }
        public AnswerTypes? answerType { get; set; }
        public QuestionCategory? questionCategory { get; set; }

    }
}
