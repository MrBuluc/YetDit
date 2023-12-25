using MediatR;
using YetDit.Application.Abstractions.Services.Authentications;

namespace YetDit.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandle : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthentication _authentication;

        public LoginUserCommandHandle(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken) =>
            (LoginUserCommandResponse)(await _authentication.LoginAsync(request.Email, request.Password));
    }
}
