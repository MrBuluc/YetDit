using Microsoft.EntityFrameworkCore;
using YetDit.Application.Repositories.Comment;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Comment
{
    public class CommentReadRepository : ReadRepository<Domain.Entities.Comment, Guid>, ICommentReadRepository
    {
        public CommentReadRepository(YetDitDbContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Comment?> GetByIdAsync(string id)
        {
            // Ardından eşleşen varlığı getir
            return await Table.Include(c => c.Post).FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }
    }
}
