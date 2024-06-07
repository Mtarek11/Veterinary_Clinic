using Application.Exceptions;
using Application.Repositories.Admins;
using Application.Repositories.BaseRepositories;
using Application.Services;
using Domain.DTOs;

namespace Persistence.Services
{
    public class AuthService(IAdminQueryRepository queryRepository, ITokenHandlerService tokenHandlerService, IUserService userService) : IAuthService
    {
        private readonly IAdminQueryRepository _queryRepository = queryRepository;
        private readonly ITokenHandlerService _tokenHandlerService = tokenHandlerService;
        private readonly IUserService _userService = userService;

        public async Task<TokenDto> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            var user = await _queryRepository.GetAdminByEmailAsync(email) ?? throw new NotFoundUserException();
            bool checkPassword = VerifyPassword(password, user.PasswordHash);

            if (checkPassword)
            {
                TokenDto token = _tokenHandlerService.CreateAccessToken(accessTokenLifeTime, user);
                token.RefreshToken = _tokenHandlerService.GenerateRefreshToken();
                await _userService.InsertRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token; 
            }
            throw new AuthenticationException();
        }

        public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _queryRepository.GetAdminByRefreshTokenAsync(refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var token = _tokenHandlerService.CreateAccessToken(15, user);
                await _userService.InsertRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            else
                throw new NotFoundUserException();
        }

        public bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);

    }
}
