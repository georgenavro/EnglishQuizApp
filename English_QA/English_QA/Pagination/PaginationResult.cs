namespace English_QA.Pagination
{
    public class PaginationResult
    {
        public static PagedResponse<List<T>> PagedResponse<T>
            (List<T> pagedData,PaginationFilter Filter,int totalRecords,UriService uriService,string route)
        {
            var Response = new PagedResponse<List<T>>(pagedData, Filter.pageNumber, Filter.pageSize);
            var totalPages = totalRecords / (double)Filter.pageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            Response.NextPage = Filter.pageNumber >= 1 && Filter.pageNumber < roundedTotalPages ? uriService.GetPageUri
                (new PaginationFilter(Filter.pageNumber + 1, Filter.pageSize), route) : null;

            Response.PreviousPage = Filter.pageNumber - 1 >= 1 && Filter.pageNumber <= roundedTotalPages 
                ? uriService.GetPageUri(new PaginationFilter(Filter.pageNumber - 1, Filter.pageSize), route) : null;

            Response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, Filter.pageSize), route);
            Response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, Filter.pageSize), route);
            Response.TotalPages = roundedTotalPages;
            Response.TotalRecords = totalRecords;
            Response.currentPage = uriService.GetPageUri(Filter, route);
            return Response;

        }
    }
}
