using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Materials.Commands.CreateMaterial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Validations
{
    public class CreateMaterialValidator : AbstractValidator<CreateMaterialCommandRequest>
    {
        public CreateMaterialValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is requierd")
                .NotNull()
                .WithMessage("Name is requierd")
                .MaximumLength(100)
                .WithMessage("Max 100 characters")
                .MinimumLength(8)
                .WithMessage("Min 8 characters");
        }
    }
}
