using YetGit.Application.DTOs.User;

namespace YetGit.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser user);
    }
}
