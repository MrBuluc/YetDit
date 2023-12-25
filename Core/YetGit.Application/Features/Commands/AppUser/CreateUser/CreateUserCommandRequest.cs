using MediatR;
using YetDit.Application.DTOs.User;

namespace YetDit.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator CreateUserModel(CreateUserCommandRequest request) => new()
        {
            Name = request.Name,
            Surname = request.Surname,
            Username = request.Username,
            Email = request.Email,
            Password = request.Password
        };
    }
}
