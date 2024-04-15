using Reddit.Models;
using Reddit.Requests;

namespace Reddit.Repositories
{
    public interface IRepository<T>
    {
        public Task<PagedList<Community>> GetAll(GetPostsRequest getPostsRequest);
    }
}
