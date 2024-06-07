using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Application.Services
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        bool VerifyPassword(string password, string hash); 
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
