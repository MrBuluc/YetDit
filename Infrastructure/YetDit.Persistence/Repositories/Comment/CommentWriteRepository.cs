using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YetDit.Application.Repositories.Comment;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Comment
{
    public class CommentWriteRepository : WriteRepository<YetDit.Domain.Entities.Comment, Guid>, ICommentWriteRepository
    {
        public CommentWriteRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
