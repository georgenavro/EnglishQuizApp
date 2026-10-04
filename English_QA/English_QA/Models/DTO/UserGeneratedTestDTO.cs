namespace English_QA.Models.DTO
{
    public class UserGeneratedTestDTO
    {
        public long Id { get; set; }
        public long TestCount { get; set; }
        public string Question { get; set; } = string.Empty;
        public string MultipleAnswer01 { get; set; } =string.Empty;
        public string MultipleAnswer02 { get; set; } = string.Empty;
        public string MultipleAnswer03 { get; set; } = string.Empty;
        public string MultipleAnswer04 { get; set; } = string.Empty;

        public long AnswerTypeID { get; set; }
        
    }
}
