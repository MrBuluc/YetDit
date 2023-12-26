using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetDit.Application.Repositories.Comment
{
    public interface ICommentReadRepository : IReadRepository<Domain.Entities.Comment, Guid>
    {
    }
}
