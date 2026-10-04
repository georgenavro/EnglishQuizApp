using Microsoft.AspNetCore.WebUtilities;

namespace English_QA.Pagination
{
    public class UriService : IruService
    {
        private readonly string Uri;
        public UriService(string uri) 
        {
            Uri = uri;
        }
        public Uri GetPageUri(PaginationFilter filter,string route) 
        {
            var endpointuri = new Uri(string.Concat(Uri, route));
            var modifieduri = QueryHelpers.AddQueryString(endpointuri.ToString(), filter.pageNumber.ToString(),filter.pageSize.ToString());
            modifieduri = QueryHelpers.AddQueryString(modifieduri,"PageSize",filter.pageSize.ToString());
            return new Uri(modifieduri);
        }
    }
}
