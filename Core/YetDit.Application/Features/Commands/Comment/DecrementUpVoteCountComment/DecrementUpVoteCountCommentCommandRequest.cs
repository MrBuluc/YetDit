using MediatR;

namespace YetDit.Application.Features.Commands.Comment.DecrementUpVoteCountComment
{
    public class DecrementUpVoteCountCommentCommandRequest : IRequest<DecrementUpVoteCountCommentCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
