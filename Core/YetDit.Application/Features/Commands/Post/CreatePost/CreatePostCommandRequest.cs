using MediatR;

namespace YetDit.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
