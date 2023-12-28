using YetDit.Application.Repositories.Post;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Post
{
    public class PostWriteRepository : WriteRepository<Domain.Entities.Post, int>, IPostWriteRepository
    {
        public PostWriteRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
