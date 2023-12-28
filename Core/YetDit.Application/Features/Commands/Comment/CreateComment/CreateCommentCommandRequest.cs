using MediatR;

namespace YetDit.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
