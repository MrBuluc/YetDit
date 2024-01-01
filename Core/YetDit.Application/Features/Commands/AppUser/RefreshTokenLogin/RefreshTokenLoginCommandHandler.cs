using MediatR;
using YetDit.Application.Abstractions.Services.Authentications;

namespace YetDit.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private readonly IAuthentication _authentication;

        public RefreshTokenLoginCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken) => new RefreshTokenLoginCommandResponse()
        {
            Token = await _authentication.RefreshLoginAsync(request.RefreshToken),
        };
    }
}
