using YetDit.Application.Repositories.Comment;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Comment
{
    public class CommentWriteRepository : WriteRepository<Domain.Entities.Comment, Guid>, ICommentWriteRepository
    {
        public CommentWriteRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
