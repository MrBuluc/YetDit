using YetDit.Application.DTOs.User;
using YetDit.Domain.Identity;

namespace YetDit.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserModel user);
        Task UpdateResfreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
