using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment
{
    public class IncrementUpVoteCountCommentCommandRequest : IRequest<IncrementUpVoteCountCommentCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
