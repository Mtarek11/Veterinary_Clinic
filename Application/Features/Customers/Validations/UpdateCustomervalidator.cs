using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Validations
{
    internal class UpdateCustomervalidator : AbstractValidator<UpdateCustomerCommandRequest>
    {
        public UpdateCustomervalidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id is requierd")
               .NotNull()
               .WithMessage("Id is requierd");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is requierd")
                .NotNull()
                .WithMessage("Name is requierd")
                .MaximumLength(100)
                .WithMessage("Max 100 characters")
                .MinimumLength(8)
                .WithMessage("Min 8 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is requierd")
                .NotNull()
                .WithMessage("Phone number is requierd")
                .MaximumLength(13)
                .WithMessage("Phone number fourmla is requierd")
                .MinimumLength(10)
                .WithMessage("Phone number fourmla is requierd");
        }
    }
}
