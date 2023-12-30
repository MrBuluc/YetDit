using Microsoft.AspNetCore.Identity;
using YetDit.Application.Abstractions.Services;
using YetDit.Application.DTOs.User;
using YetDit.Domain.Identity;

namespace YetDit.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUserModel model)
        {
            Guid guid = Guid.NewGuid();
            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                Id = guid,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                CreatedByUserId = guid.ToString()
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = identityResult.Succeeded };

            if (identityResult.Succeeded)
                response.Message = "Kullanıcı Başarıyla Oluşturulmuştur";
            else
                foreach (var error in identityResult.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }
    }
}
