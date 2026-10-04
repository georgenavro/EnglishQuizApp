namespace English_QA.Pagination
{
    public class PaginationFilter
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public PaginationFilter()
        {
            pageNumber = 1;
            pageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber < 1 ? 1: pageNumber;
            this.pageSize = pageSize > 200 ? 10 : pageSize;
        }
    }
}
