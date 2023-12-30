using MediatR;

namespace YetDit.Application.Features.Commands.Comment.IncrementUpVoteCountComment
{
    public class IncrementUpVoteCountCommentCommandRequest : IRequest<IncrementUpVoteCountCommentCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
