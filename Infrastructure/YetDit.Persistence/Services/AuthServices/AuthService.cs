using Microsoft.AspNetCore.Identity;
using YetDit.Domain.Identity;
using YetDit.Application.Abstractions.Services.Authentications;
using YetDit.Application.Exceptions;
using YetDit.Application.DTOs;
using YetDit.Application.Abstractions.Token;
using YetDit.Application.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace YetDit.Persistence.Services.AuthServices
{
    public class AuthService : IAuthentication
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (appUser is null)
                throw new NotFoundUserException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, appUser);
                await _userService.UpdateRefreshToken(token.RefreshToken, appUser, token.Expiration, 40);
                await _userManager.AddClaimAsync(appUser, new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", appUser.UserName!));

                return token;

            }
            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshLoginAsync(string refreshToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (appUser is not null && appUser.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, appUser);
                await _userService.UpdateRefreshToken(token.RefreshToken, appUser, token.Expiration, 10);
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}
