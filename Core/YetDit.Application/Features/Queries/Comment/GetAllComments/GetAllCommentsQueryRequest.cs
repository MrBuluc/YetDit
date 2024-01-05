using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetDit.Application.Features.Queries.Comment.GetAllComments
{
    public class GetAllCommentsQueryRequest : IRequest<GetAllCommentsQueryResponse>
    {
        public int Id { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;

    }
}
