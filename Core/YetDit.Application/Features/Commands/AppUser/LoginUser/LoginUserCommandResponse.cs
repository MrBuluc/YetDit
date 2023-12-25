using YetDit.Application.DTOs;

namespace YetDit.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<LoginUserCommandResponseError> Errors { get; set; }

        public static explicit operator LoginUserCommandResponse(AuthenticationLoginResponse response) => new()
        {
            Succeeded = response.Succeeded,
            Errors = response.Errors.Select(error => new LoginUserCommandResponseError()
            {
                Code = error.Code,
                Message = error.Message,
            })
        };
    }

    public class LoginUserCommandResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
