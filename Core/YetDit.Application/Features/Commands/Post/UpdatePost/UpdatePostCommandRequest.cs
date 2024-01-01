using MediatR;
using System.Security.Claims;

namespace YetDit.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Claim? Claim { get; set; }
    }
}
