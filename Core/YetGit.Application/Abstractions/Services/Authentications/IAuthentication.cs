using YetGit.Application.DTOs;

namespace YetGit.Application.Abstractions.Services.Authentications
{
    public interface IAuthentication
    {
        Task<AuthenticationLoginResponse> LoginAsync(string email, string password);
    }
}
