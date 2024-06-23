using NuGet.Protocol;
using Reddit.Models;
using Reddit.Requests;
using System.Linq.Expressions;

namespace Reddit.Repositories
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly ApplcationDBContext _context;

        public CommunityRepository(ApplcationDBContext applicationDBContext)
        {
            this._context = applicationDBContext;
        }

        public async Task<PagedList<Community>> GetAll(GetPostsRequest getPostsRequest)
        {

            Console.Out.WriteLineAsync(getPostsRequest.ToJson());

            IQueryable<Community> Comunityquery = _context.Communities;

            if (!string.IsNullOrWhiteSpace(getPostsRequest.SearchKey))
            {
                Comunityquery = Comunityquery.Where(p =>
                    p.Name.Contains(getPostsRequest.SearchKey) ||
                    p.Description.Contains(getPostsRequest.SearchKey));
            }



   
            if (getPostsRequest.isAscending == true)
            {
                Comunityquery = Comunityquery.OrderBy(GetSortProperty(getPostsRequest.SortKey));
            }
            else
            {
                Comunityquery = Comunityquery.OrderByDescending(GetSortProperty(getPostsRequest.SortKey));
            }




            return await PagedList<Community>.CreateAsync(Comunityquery, getPostsRequest.pageNumber, getPostsRequest.PageSize);
        }

        private static Expression<Func<Community, object>> GetSortProperty(string SortColumn) =>
      SortColumn?.ToLower() switch
      {
          "date" => comunity => comunity.CreatedAt,
          "posts"=> comunity=> comunity.Posts.Count(),
          "subs" => comunity=>comunity.UserSubscribers.Count(),
          _ => comunity => comunity.CommunityId
      };
    }
}
