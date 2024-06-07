using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshTokenUser
{
    public record RefreshTokenUserReqeust : IRequest<RefreshTokenUserResponse>
    {
        public string? RefreshToken { get; set; }
    }
}
