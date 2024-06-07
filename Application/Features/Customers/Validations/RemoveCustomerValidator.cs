using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.RemoveCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Validations
{
    internal class RemoveCustomerValidator : AbstractValidator<RemoveCustomerCommandRequest>
    {
        public RemoveCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is requierd")
                .NotNull()
                .WithMessage("Id is requierd");

        }
    }
}
