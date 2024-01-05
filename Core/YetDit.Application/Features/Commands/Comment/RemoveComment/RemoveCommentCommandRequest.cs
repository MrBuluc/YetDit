using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandRequest : IRequest<RemoveCommentCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
