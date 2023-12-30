using YetDit.Application.DTOs;

namespace YetDit.Application.Abstractions.Services.Authentications
{
    public interface IAuthentication
    {
        Task<DTOs.Token> LoginAsync(string email, string password, int accessTokenLifeTime);
        Task<DTOs.Token> RefreshLoginAsync(string refreshtoken);
    }
}
