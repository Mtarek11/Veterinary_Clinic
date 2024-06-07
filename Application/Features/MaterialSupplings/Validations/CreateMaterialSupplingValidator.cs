using Application.Features.Materials.Commands.CreateMaterial;
using Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Validations
{
    public class CreateMaterialSupplingValidator : AbstractValidator<CreateMaterialSupplingCommendRequest>
    {
        public CreateMaterialSupplingValidator()
        {
            RuleFor(x => x.MaterialId)
                .NotEmpty()
                .WithMessage("Material id is required is requierd")
                .NotNull()
                .WithMessage("Material id is required is requierd");

            RuleFor(x => x.SupplyCount)
               .NotEmpty()
               .WithMessage("Supply count is requierd")
               .NotNull()
               .WithMessage("Supply count is requierd");

            RuleFor(x => x.SupplyPrice)
               .NotEmpty()
               .WithMessage("Supply price is requierd")
               .NotNull()
               .WithMessage("Supply price is requierd");

            RuleFor(x => x.SupplyDate)
               .NotEmpty()
               .WithMessage("Supply date is requierd")
               .NotNull()
               .WithMessage("Supply date is requierd");

        }
    }
}
