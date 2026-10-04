
namespace English_QA.Pagination
{
    public class PagedResponse<T> : ResponseWrapper<T>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public Uri currentPage { get; set; } = default!;
        public Uri FirstPage { get; set; } = default!;
        public Uri LastPage { get; set; } = default!;
        public long TotalPages { get; set; }
        public long TotalRecords { get; set; }
        public Uri NextPage { get; set; } = default!;
        public Uri PreviousPage { get; set; } = default!;


        public PagedResponse(T data, int PageNumber, int PageSize)
        {
            pageNumber = PageNumber;
            pageSize = PageSize;
            Data = data;
            Message = string.Empty;
            succeded = true;
            Errors = new string[0];

        }

    }
}
