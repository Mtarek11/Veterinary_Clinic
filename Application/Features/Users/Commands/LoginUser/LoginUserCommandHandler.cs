using Application.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler(IAuthService authService, IMapper mapper) : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService = authService;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.Email!, request.Password!, 5000);
            var mapped = _mapper.Map<LoginUserCommandResponse>(token);
            return mapped;
        }
    }
} 
