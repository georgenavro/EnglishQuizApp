using English_QA.Models;

namespace English_QA.Seeders
{
    public class DbSetInitializer
    {
        public static void Initializer(DBContext dBContext)
        {
            dBContext.Database.EnsureCreated();
            
            if (!dBContext.UserType.Any())
            {
                UserType_Seeder.Seed(dBContext);
            }
            if (!dBContext.Users.Any())
            {
                Users_Seeder.Seed(dBContext);
            }
            if (!dBContext.AnswerTypes.Any())
            {
                AnswerType_Seeder.Seed(dBContext);
            }
            if (!dBContext.QuestionCategory.Any())
            {
                Question_Category_Seeder.Seed(dBContext);
            }
            if (!dBContext.QA.Any())
            {
                QA_Seeder.Seed(dBContext);
            }

        }
    }
}
