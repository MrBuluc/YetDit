using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public Claim? Claim { get; set; }
    }
}
