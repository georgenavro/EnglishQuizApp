using English_QA.Models;
using English_QA.Models.DatabaseModels;

namespace English_QA.Seeders
{
    public class AnswerType_Seeder
    {
        public static void Seed(DBContext dBContext)
        {
            var answerType = new List<AnswerTypes>
            {
                new AnswerTypes {Id = 1, AnswerType = "Text"},
                new AnswerTypes {Id = 2, AnswerType = "Multiple Choice"},

            };
            dBContext.AnswerTypes.AddRange(answerType);
            dBContext.SaveChanges();
        }
    }
}
