using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshTokenUser
{
    public record RefreshTokenUserResponse
    {
        public TokenDto? Token { get; set; }
    }
}
