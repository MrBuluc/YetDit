using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Post.RemovePost
{
    public class RemovePostCommandRequest : IRequest<RemovePostCommandResponse>
    {
        public string Id { get; set; }
        public Claim? Claim { get; set; }
    }
}
