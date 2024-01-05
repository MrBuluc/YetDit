using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment
{
    public class DecrementUpVoteCountCommentCommandRequest : IRequest<DecrementUpVoteCountCommentCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
