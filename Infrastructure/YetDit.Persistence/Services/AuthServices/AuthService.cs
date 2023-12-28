using Microsoft.AspNetCore.Identity;
using YetDit.Domain.Identity;
using YetDit.Application.Abstractions.Services.Authentications;
using YetDit.Application.Exceptions;
using YetDit.Application.DTOs;

namespace YetDit.Persistence.Services.AuthServices
{
    public class AuthService : IAuthentication
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationLoginResponse> LoginAsync(string email, string password)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (appUser is null)
                throw new NotFoundUserException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);

            if (result.Succeeded)
            {
                return new()
                {
                    Succeeded = true,
                };

            }
            throw new AuthenticationErrorException();
        }
    }
}
