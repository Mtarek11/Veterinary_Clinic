using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshTokenUser
{
    public class RefreshTokenUserHandler(IAuthService authService) : IRequestHandler<RefreshTokenUserReqeust, RefreshTokenUserResponse>
    {
        private readonly IAuthService _authService = authService;

        public async Task<RefreshTokenUserResponse> Handle(RefreshTokenUserReqeust request, CancellationToken cancellationToken)
        {
            var token = await _authService.RefreshTokenLoginAsync(request.RefreshToken!);
            return new()
            {
                Token = token 
            };
        }
    }
}
