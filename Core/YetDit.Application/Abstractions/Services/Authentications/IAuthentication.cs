using YetDit.Application.DTOs;

namespace YetDit.Application.Abstractions.Services.Authentications
{
    public interface IAuthentication
    {
        Task<AuthenticationLoginResponse> LoginAsync(string email, string password);
    }
}
