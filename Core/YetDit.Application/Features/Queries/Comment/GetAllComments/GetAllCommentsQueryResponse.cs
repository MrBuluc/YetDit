using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YetDit.Domain.Identity;

namespace YetDit.Application.Features.Queries.Comment.GetAllComments
{
    public class GetAllCommentsQueryResponse
    {
        public int TotalCount { get; set; }
        public object Comments { get; set; }
    }
}
