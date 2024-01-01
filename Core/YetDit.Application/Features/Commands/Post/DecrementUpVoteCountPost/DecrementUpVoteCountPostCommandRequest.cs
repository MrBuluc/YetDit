using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Post.DecrementUpVoteCountPost
{
    public class DecrementUpVoteCountPostCommandRequest : IRequest<DecrementUpVoteCountPostCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
