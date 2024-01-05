using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Claim? Claim { get; set; }
    }
}
