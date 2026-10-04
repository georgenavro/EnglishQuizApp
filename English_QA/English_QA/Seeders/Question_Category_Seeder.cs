using English_QA.Models;
using English_QA.Models.DatabaseModels;

namespace English_QA.Seeders
{
    public class Question_Category_Seeder
    {
        public static void Seed(DBContext dBContext)
        {
            var questionCategory = new List<QuestionCategory>
            {
                new QuestionCategory {Id = 1, questionCategory= "No Category" },
                new QuestionCategory {Id = 2, questionCategory= "Simple Present" },
                new QuestionCategory {Id = 3, questionCategory= "Simple Past" },
                new QuestionCategory {Id = 4, questionCategory= "Present Perfect" },
                new QuestionCategory {Id = 5, questionCategory= "Simple Future" },
                new QuestionCategory {Id = 6, questionCategory= "Present-Past" },
                new QuestionCategory {Id = 7, questionCategory= "Present-Future" },
                new QuestionCategory {Id = 8, questionCategory= "Past-Future" },
                new QuestionCategory {Id = 9, questionCategory= "Present-Past Perfect" },
                new QuestionCategory {Id = 10,questionCategory= "Present-Future Perfect" },
                new QuestionCategory {Id = 11,questionCategory= "Past-Future Perfect" }

            };
            dBContext.QuestionCategory.AddRange(questionCategory);
            dBContext.SaveChanges();
        }
    }
}
