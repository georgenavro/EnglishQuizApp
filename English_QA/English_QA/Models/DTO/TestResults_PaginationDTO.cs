using Microsoft.Extensions.Configuration.UserSecrets;

namespace English_QA.Models.DTO
{
    public class TestResults_PaginationDTO
    {
        public long ID { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string UserAnswer { get; set; } = string.Empty;
        public long CorrectAnswers { get; set; }
        public long CountQuestions {  get; set; }
        public float Results {  get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public long TestPerAttempt { get; set; }

    }
}
