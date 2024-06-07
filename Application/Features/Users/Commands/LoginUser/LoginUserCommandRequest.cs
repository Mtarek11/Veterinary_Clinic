using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
