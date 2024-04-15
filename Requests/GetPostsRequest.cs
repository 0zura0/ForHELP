using Microsoft.AspNetCore.Mvc;

namespace Reddit.Requests
{
    public class GetPostsRequest
    {
        [FromQuery]
        public string? SearchKey { get; set; }

        [FromQuery]
        public string? SortKey { get; set; }

        [FromQuery]
        public bool? isAscending { get; set; }


        [FromQuery]
        public int pageNumber { get; set; } = 1; 

        [FromQuery]
        public int PageSize { get; set; } = 10; 
    }
}
