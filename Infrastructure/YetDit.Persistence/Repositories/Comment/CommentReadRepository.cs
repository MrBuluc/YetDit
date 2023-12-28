using YetDit.Application.Repositories.Comment;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Comment
{
    public class CommentReadRepository : ReadRepository<Domain.Entities.Comment, Guid>, ICommentReadRepository
    {
        public CommentReadRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
