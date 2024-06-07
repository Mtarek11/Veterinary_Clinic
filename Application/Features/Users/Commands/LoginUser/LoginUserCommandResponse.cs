using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommandResponse
    {
        public TokenDto? Token { get; set; } 
    }
}
