using MediatR;

namespace YetDit.Application.Features.Commands.Post.RemovePost
{
    public class RemovePostCommandRequest : IRequest<RemovePostCommandResponse>
    {
        public string Id { get; set; }
    }
}
