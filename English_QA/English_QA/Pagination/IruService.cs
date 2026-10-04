namespace English_QA.Pagination
{
    public interface IruService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
