using MediatR;

namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountPostCommandRequest : IRequest<IncrementUpVoteCountPostCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
