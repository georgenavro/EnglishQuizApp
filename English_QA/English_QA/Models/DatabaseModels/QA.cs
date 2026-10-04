namespace English_QA.Models.DatabaseModels
{
    public class QA
    {
        public long Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public long questionCategoryID { get; set; }
        public long AnswerTypeID { get; set; }
        public string MultipleAnswer01 { get; set; } = string.Empty;
        public string MultipleAnswer02 { get; set; } = string.Empty;
        public string MultipleAnswer03 { get; set; } = string.Empty;
        public string MultipleAnswer04 { get; set; } = string.Empty;
        public AnswerTypes? answerType { get; set; }
        public QuestionCategory? questionCategory { get; set; }

    }
}
