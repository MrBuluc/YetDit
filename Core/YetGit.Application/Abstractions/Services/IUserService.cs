using YetDit.Application.DTOs.User;

namespace YetDit.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUserModel user);
    }
}
