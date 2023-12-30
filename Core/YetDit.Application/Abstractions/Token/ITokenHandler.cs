using YetDit.Domain.Identity;

namespace YetDit.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
