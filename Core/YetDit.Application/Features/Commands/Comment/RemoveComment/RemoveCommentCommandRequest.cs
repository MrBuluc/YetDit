using MediatR;

namespace YetDit.Application.Features.Commands.Comment.RemoveComment
{
    public class RemoveCommentCommandRequest : IRequest<RemoveCommentCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
