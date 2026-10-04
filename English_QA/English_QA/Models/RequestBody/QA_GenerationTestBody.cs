using English_QA.Models.DatabaseModels;

namespace English_QA.Models.RequestBody
{
    public class QA_GenerationTestBody
    {
        public long questionCategoryID { get; set; }
        public long AnswerTypeID { get; set; }
        public long userID { get; set; } 
        public int quantity { get; set; }

    }
}
