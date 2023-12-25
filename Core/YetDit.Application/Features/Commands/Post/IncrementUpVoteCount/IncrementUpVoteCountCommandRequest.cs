using MediatR;

namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountCommandRequest : IRequest<IncrementUpVoteCountCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
