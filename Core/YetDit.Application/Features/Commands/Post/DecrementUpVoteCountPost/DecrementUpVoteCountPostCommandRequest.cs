using MediatR;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost
{
    public class DecrementUpVoteCountPostCommandRequest : IRequest<DecrementUpVoteCountPostCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
