using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YetDit.Application.Abstractions.Services;
using YetDit.Domain.Identity;
using YetDit.Application.Abstractions.Services.Authentications;
using YetDit.Domain.Identity;
using YetDit.Application.Abstractions.Services.Token;
using YetDit.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using YetDit.Application.Exceptions;
namespace YetDit.Persistence.Services.AuthServices
{
    public class AuthService : IAuthentication
    {
        readonly UserManager<YetDit.Domain.Identity.AppUser> _userManager;
        readonly SignInManager<YetDit.Domain.Identity.AppUser> _signInManager;

        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userService = userService;
        }

        async Task<Token> CreateUserExternalAsync(AppUser user, string name, string surname, string email, UserLoginInfo info, int accessTokenLifeTime)
        {
            bool result = user != null;

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid(),
                        Email = email,
                        Name = name,
                        Surname = surname,
                        UserName = email
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
                throw new Exception("Invalid External Authentication");

            Token token = _tokenHandler.CreateAccessToken(15 * 60, user);
            await _userService.UpdateResfreshToken(token.RefreshToken, user, token.Expiration, 5);
            return token;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            YetDit.Domain.Identity.AppUser appUser = await _userManager.FindByNameAsync(usernameOrEmail);
            if (appUser == null)
                appUser = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (appUser == null)
                throw new NotFoundUserException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, appUser);
                await _userService.UpdateResfreshToken(token.RefreshToken, appUser, token.Expiration, 40);
                return token;

            }
            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshLoginAsync(string refreshToken)
        {
            AppUser? appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (appUser != null && appUser.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, appUser);
                await _userService.UpdateResfreshToken(token.RefreshToken, appUser, token.Expiration, 10);
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}
