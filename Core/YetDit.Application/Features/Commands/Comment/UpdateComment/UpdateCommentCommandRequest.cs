using MediatR;

namespace YetDit.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
