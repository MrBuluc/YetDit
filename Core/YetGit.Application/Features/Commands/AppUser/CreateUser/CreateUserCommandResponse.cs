using MediatR;
using YetGit.Application.DTOs.User;

namespace YetGit.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandResponse : IRequest<CreateUserCommandRequest>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static explicit operator CreateUserCommandResponse(CreateUserResponse response) => new()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}
