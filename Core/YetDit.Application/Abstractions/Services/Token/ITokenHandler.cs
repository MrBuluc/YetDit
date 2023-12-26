using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YetDit.Domain.Identity;

namespace YetDit.Application.Abstractions.Services.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
