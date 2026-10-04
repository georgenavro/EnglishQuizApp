namespace English_QA.Models.RequestBody
{
    public class GetUserTestSelectionBody
    {
        public long Id { get; set; }
        public long userID { get; set; }
        public long questionCategoryID { get; set; }
        public long answerTypeID { get; set; }
        public long quantity { get; set; }
    }
}
