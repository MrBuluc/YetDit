using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YetDit.Domain.Entities;
using YetDit.Application.Repositories.Comment;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Comment
{
    public class CommentReadRepository : ReadRepository<YetDit.Domain.Entities.Comment, Guid>, ICommentReadRepository
    {
        public CommentReadRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
