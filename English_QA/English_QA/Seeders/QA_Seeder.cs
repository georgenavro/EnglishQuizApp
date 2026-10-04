using English_QA.Models;
using English_QA.Models.DatabaseModels;

namespace English_QA.Seeders
{
    public class QA_Seeder
    {
        public static void Seed(DBContext dBContext)
        {
            var qa = new List<QA>
        {
                //AreaOfQuestion = withoutarea answer type= Text
            // 7 auxiliary/modal/helping verb type
            new QA {Id = 1, Question = "They _____ playing football when it started to rain.", Answer = "were", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 2, Question = "I _____ seen this movie twice.", Answer = "have", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 3, Question = "She _____ already eaten her lunch.", Answer = "has", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 4, Question = "He _____ not understand the instructions.", Answer = "does", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 5, Question = "We _____ go to the park if it doesn't rain.", Answer = "will", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 6, Question = "You _____ be careful with that knife.", Answer = "must", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 7, Question = "He _____ always late for school.", Answer = "is", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},

            // 13 with more interesting/general words (verbs, nouns, adjectives etc.)
            new QA {Id = 8, Question = "They _____ a new car last week.", Answer = "bought", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 9, Question = "He _____ his phone on the bus.", Answer = "forgot", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 10, Question = "We _____ the room before guests arrived.", Answer = "cleaned", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 11, Question = "She _____ a cake for her brother's birthday.", Answer = "baked", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 12, Question = "He always _____ his keys on the table.", Answer = "leaves", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 13, Question = "They _____ their dog every morning.", Answer = "walk", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 14, Question = "We _____ dinner together as a family.", Answer = "eat", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 15, Question = "I _____ my homework before watching TV.", Answer = "finished", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 16, Question = "The child _____ loudly in the store.", Answer = "cried", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 17, Question = "He _____ the book back to the library.", Answer = "returned", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 18, Question = "We _____ the answer after thinking hard.", Answer = "found", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 19, Question = "She _____ the letter carefully.", Answer = "read", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 20, Question = "They _____ the door before leaving.", Answer = "locked", AnswerTypeID = 1, questionCategoryID = 1, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            
            // 20 questions-answers AreaOfQuestion= simple present || answer type= Text
            new QA {Id = 21, Question = "He _____ every morning to stay fit.", Answer = "runs", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 22, Question = "They _____ watching cartoons on weekends.", Answer = "like", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 23, Question = "We _____ to school by bus.", Answer = "go", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 24, Question = "She _____ tea every afternoon.", Answer = "drinks", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 25, Question = "He _____ an apple every day.", Answer = "eats", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 26, Question = "The children _____ in the park after school.", Answer = "play", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 27, Question = "My dad _____ the news every evening.", Answer = "watches", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 28, Question = "I _____ English at the library.", Answer = "study", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 29, Question = "They _____ Spanish at home.", Answer = "speak", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 30, Question = "She always _____ to work.", Answer = "walks", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 31, Question = "He _____ emails every morning.", Answer = "writes", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 32, Question = "We _____ to music while cooking.", Answer = "listen", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 33, Question = "My brother _____ me with my homework.", Answer = "helps", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 34, Question = "They _____ more time to finish the project.", Answer = "need", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 35, Question = "She _____ her phone for online classes.", Answer = "uses", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 36, Question = "I _____ books before going to bed.", Answer = "read", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 37, Question = "We _____ in a small town near the sea.", Answer = "live", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 38, Question = "He _____ the door quietly.", Answer = "closes", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 39, Question = "They always _____ the windows in the morning.", Answer = "open", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            new QA {Id = 40, Question = "My mom _____ delicious meals every day.", Answer = "cooks", AnswerTypeID = 1, questionCategoryID = 2, MultipleAnswer01 = "", MultipleAnswer02 = "", MultipleAnswer03 = "", MultipleAnswer04 = ""},
            
            // 20 Question-Category= without area || answer type =Multi
            new QA {Id = 221, Question = "He _____ every morning to stay fit.", Answer = "ran", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "runs", MultipleAnswer02 = "ran", MultipleAnswer03 = "will run", MultipleAnswer04 = "has run"},
            new QA {Id = 222, Question = "They _____ watching cartoons on weekends.", Answer = "have enjoyed", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "enjoy", MultipleAnswer02 = "enjoyed", MultipleAnswer03 = "have enjoyed", MultipleAnswer04 = "will enjoy"},
            new QA {Id = 223, Question = "We _____ to school by bus.", Answer = "used to go", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "go", MultipleAnswer02 = "used to go", MultipleAnswer03 = "have gone", MultipleAnswer04 = "will go"},
            new QA {Id = 224, Question = "She _____ tea every afternoon.", Answer = "drank", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "drinks", MultipleAnswer02 = "drank", MultipleAnswer03 = "has drunk", MultipleAnswer04 = "will drink"},
            new QA {Id = 225, Question = "He _____ an apple every day.", Answer = "has eaten", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "eats", MultipleAnswer02 = "ate", MultipleAnswer03 = "has eaten", MultipleAnswer04 = "will eat"},
            new QA {Id = 226, Question = "The children _____ in the park after school.", Answer = "will play", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "play", MultipleAnswer02 = "played", MultipleAnswer03 = "have played", MultipleAnswer04 = "will play"},
            new QA {Id = 227, Question = "My dad _____ the news every evening.", Answer = "watched", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "watches", MultipleAnswer02 = "watched", MultipleAnswer03 = "has watched", MultipleAnswer04 = "will watch"},
            new QA {Id = 228, Question = "I _____ English at the library.", Answer = "have studied", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "study", MultipleAnswer02 = "studied", MultipleAnswer03 = "have studied", MultipleAnswer04 = "will study"},
            new QA {Id = 229, Question = "They _____ Spanish at home.", Answer = "speak", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "spoke", MultipleAnswer02 = "speak", MultipleAnswer03 = "have spoken", MultipleAnswer04 = "will speak"},
            new QA {Id = 230, Question = "She always _____ to work.", Answer = "will walk", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "walks", MultipleAnswer02 = "walked", MultipleAnswer03 = "has walked", MultipleAnswer04 = "will walk"},
            new QA {Id = 231, Question = "He _____ emails every morning.", Answer = "has written", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "writes", MultipleAnswer02 = "wrote", MultipleAnswer03 = "has written", MultipleAnswer04 = "will write"},
            new QA {Id = 232, Question = "We _____ to music while cooking.", Answer = "listened", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "listen", MultipleAnswer02 = "listened", MultipleAnswer03 = "have listened", MultipleAnswer04 = "will listen"},
            new QA {Id = 233, Question = "My brother _____ me with my homework.", Answer = "helps", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "helped", MultipleAnswer02 = "has helped", MultipleAnswer03 = "will help", MultipleAnswer04 = "helps"},
            new QA {Id = 234, Question = "They _____ more time to finish the project.", Answer = "will need", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "need", MultipleAnswer02 = "needed", MultipleAnswer03 = "have needed", MultipleAnswer04 = "will need"},
            new QA {Id = 235, Question = "She _____ her phone for online classes.", Answer = "uses", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "used", MultipleAnswer02 = "has used", MultipleAnswer03 = "uses", MultipleAnswer04 = "will use"},
            new QA {Id = 236, Question = "I _____ books before going to bed.", Answer = "have read", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "read", MultipleAnswer02 = "have read", MultipleAnswer03 = "will read", MultipleAnswer04 = "am reading"},
            new QA {Id = 237, Question = "We _____ in a small town near the sea.", Answer = "lived", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "live", MultipleAnswer02 = "lived", MultipleAnswer03 = "have lived", MultipleAnswer04 = "will live"},
            new QA {Id = 238, Question = "He _____ the door quietly.", Answer = "will close", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "closes", MultipleAnswer02 = "closed", MultipleAnswer03 = "has closed", MultipleAnswer04 = "will close"},
            new QA {Id = 239, Question = "They always _____ the windows in the morning.", Answer = "have opened", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "open", MultipleAnswer02 = "opened", MultipleAnswer03 = "have opened", MultipleAnswer04 = "will open"},
            new QA {Id = 240, Question = "My mom _____ delicious meals every day.", Answer = "cooked", AnswerTypeID = 2, questionCategoryID = 1, MultipleAnswer01 = "cooks", MultipleAnswer02 = "cooked", MultipleAnswer03 = "has cooked", MultipleAnswer04 = "will cook"},

            
            // 20 Question-Category= simple present || answer type =Multi
            new QA {Id = 241, Question = "He always _____ his coffee with sugar.", Answer = "drinks", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "eat", MultipleAnswer02 = "take", MultipleAnswer03 = "drinks", MultipleAnswer04 = "cook"},
            new QA {Id = 242, Question = "They _____ to the gym after work.", Answer = "walk", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "walk", MultipleAnswer02 = "sleeps", MultipleAnswer03 = "eats", MultipleAnswer04 = "drinks"},
            new QA {Id = 243, Question = "My mom _____ amazing food.", Answer = "cooks", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "sings", MultipleAnswer02 = "cooks", MultipleAnswer03 = "jumps", MultipleAnswer04 = "reads"},
            new QA {Id = 244, Question = "We _____ TV together every night.", Answer = "watch", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "drive", MultipleAnswer02 = "bake", MultipleAnswer03 = "watch", MultipleAnswer04 = "paint"},
            new QA {Id = 245, Question = "I _____ the guitar in my free time.", Answer = "play", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "fix", MultipleAnswer02 = "play", MultipleAnswer03 = "write", MultipleAnswer04 = "sleep"},
            new QA {Id = 246, Question = "She always _____ the window before sleeping.", Answer = "opens", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "opens", MultipleAnswer02 = "jump", MultipleAnswer03 = "read", MultipleAnswer04 = "run"},
            new QA {Id = 247, Question = "You _____ your phone everywhere.", Answer = "carry", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "dance", MultipleAnswer02 = "drive", MultipleAnswer03 = "carry", MultipleAnswer04 = "walk"},
            new QA {Id = 248, Question = "My dad _____ to work at 8 a.m.", Answer = "drives", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "works", MultipleAnswer02 = "cooks", MultipleAnswer03 = "drives", MultipleAnswer04 = "sleeps"},
            new QA {Id = 249, Question = "We always _____ our hands before dinner.", Answer = "wash", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "build", MultipleAnswer02 = "wash", MultipleAnswer03 = "paint", MultipleAnswer04 = "write"},
            new QA {Id = 250, Question = "He _____ his room every weekend.", Answer = "clean", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "clean", MultipleAnswer02 = "sing", MultipleAnswer03 = "wear", MultipleAnswer04 = "draw"},
            new QA {Id = 251, Question = "You _____ very fast.", Answer = "run", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "cook", MultipleAnswer02 = "swim", MultipleAnswer03 = "run", MultipleAnswer04 = "close"},
            new QA {Id = 252, Question = "The teacher _____ the students every day.", Answer = "teaches", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "teaches", MultipleAnswer02 = "watches", MultipleAnswer03 = "listens", MultipleAnswer04 = "catches"},
            new QA {Id = 253, Question = "They _____ emails to clients daily.", Answer = "write", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "draw", MultipleAnswer02 = "write", MultipleAnswer03 = "open", MultipleAnswer04 = "sleep"},
            new QA {Id = 254, Question = "She _____ her hair every morning.", Answer = "brushes", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "brushes", MultipleAnswer02 = "eats", MultipleAnswer03 = "drives", MultipleAnswer04 = "plays"},
            new QA {Id = 255, Question = "My brother _____ late on weekends.", Answer = "sleeps", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "wakes", MultipleAnswer02 = "sleeps", MultipleAnswer03 = "opens", MultipleAnswer04 = "buys"},
            new QA {Id = 256, Question = "We _____ the bus to school.", Answer = "take", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "take", MultipleAnswer02 = "fly", MultipleAnswer03 = "paint", MultipleAnswer04 = "clean"},
            new QA {Id = 257, Question = "I _____ my bike every afternoon.", Answer = "ride", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "eat", MultipleAnswer02 = "ride", MultipleAnswer03 = "close", MultipleAnswer04 = "read"},
            new QA {Id = 258, Question = "She _____ lunch at noon.", Answer = "eats", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "eats", MultipleAnswer02 = "swims", MultipleAnswer03 = "writes", MultipleAnswer04 = "draws"},
            new QA {Id = 259, Question = "They _____ games on their phones.", Answer = "play", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "sleep", MultipleAnswer02 = "draw", MultipleAnswer03 = "play", MultipleAnswer04 = "wash"},
            new QA {Id = 260, Question = "The baby often _____ at night.", Answer = "cries", AnswerTypeID = 2, questionCategoryID = 2, MultipleAnswer01 = "sleeps", MultipleAnswer02 = "cries", MultipleAnswer03 = "studies", MultipleAnswer04 = "types"}
        };

            dBContext.QA.AddRange(qa);
            dBContext.SaveChanges();
        }
    }
}
