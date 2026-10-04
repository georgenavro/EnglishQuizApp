namespace English_QA.Models.DTO
{
    public class GetPreviousUserTestDTO
    {
        public long Id { get; set; }
        public long UserID { get; set; }
        public long QuestionCategoryID { get; set; }
        public long AnswerTypeID { get; set; }
        public long TestCount { get; set; }

    }
}
