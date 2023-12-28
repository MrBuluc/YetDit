using YetDit.Application.Repositories.Post;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Post
{
    public class PostReadRepository : ReadRepository<Domain.Entities.Post, int>, IPostReadRepository
    {
        public PostReadRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
