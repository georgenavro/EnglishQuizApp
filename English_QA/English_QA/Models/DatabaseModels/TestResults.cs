namespace English_QA.Models.DatabaseModels
{
    public class TestResults
    {
        public long Id { get; set; }
        public string UserAnswer { get; set; } = string.Empty;
        public long CorrectAnswers { get; set; }
        public long CountQuestions { get; set; }
        public float Results { get; set; }
        public long TestPerAttempt { get; set; }
        public long TestResultCount { get; set; }
        public long UserTestID { get; set; }

        public UserTest? UserTest { get; set; }

    }
}
