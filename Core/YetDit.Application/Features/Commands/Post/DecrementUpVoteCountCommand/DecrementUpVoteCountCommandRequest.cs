using MediatR;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountCommand
{
    public class DecrementUpVoteCountCommandRequest : IRequest<DecrementUpVoteCountCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
