using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Materials.Commands.RemoveMaterial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Validations
{
    public class RemoveMaterialValidator : AbstractValidator<RemoveMaterialCommandRequest>
    {
        public RemoveMaterialValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id is requierd")
               .NotNull()
               .WithMessage("Id is requierd");
        }
    }
}
