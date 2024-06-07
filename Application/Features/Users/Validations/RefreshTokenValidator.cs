using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RefreshTokenUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validations
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenUserReqeust>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .NotNull()
                .WithMessage("Refresh token is requierd");
        }
    }
}
