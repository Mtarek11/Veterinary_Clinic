using Application.Features.Users.Commands.LoginUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validations
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is requierd")
                .EmailAddress()
                .WithMessage("Email fourmla is requierd");

            RuleFor(x => x.Password)
             .NotEmpty()
             .NotNull()
             .WithMessage("Password is required.")
             .MinimumLength(8)
             .WithMessage("Password must be at least 8 characters long.")
             .Matches("[0-9]")
             .WithMessage("Password must contain at least one numeric digit.")
             .Matches("[A-Z]")
             .WithMessage("Password must contain at least one uppercase letter.")
             .Matches("[a-z]")
             .WithMessage("Password must contain at least one lowercase letter.")
             .Matches("[^a-zA-Z0-9]")
             .WithMessage("Password must contain at least one symbol.");
        }
    }
}