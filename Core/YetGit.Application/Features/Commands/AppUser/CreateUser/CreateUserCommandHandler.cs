using MediatR;
using YetGit.Application.Abstractions.Services;
using YetGit.Application.DTOs.User;

namespace YetGit.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken) => 
            (CreateUserCommandResponse) (await _userService.CreateAsync((CreateUserModel) request));
    }
}
