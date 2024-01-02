using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Post.IncrementUpVoteCount
{
    public class IncrementUpVoteCountPostCommandRequest : IRequest<IncrementUpVoteCountPostCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
