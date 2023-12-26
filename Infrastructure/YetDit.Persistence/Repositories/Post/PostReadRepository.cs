using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YetDit.Application.Repositories.Comment;
using YetDit.Application.Repositories.Post;
using YetDit.Persistence.Contexts;

namespace YetDit.Persistence.Repositories.Post
{
    public class PostReadRepository : ReadRepository<YetDit.Domain.Entities.Post, int>, IPostReadRepository
    {
        public PostReadRepository(YetDitDbContext context) : base(context)
        {
        }
    }
}
