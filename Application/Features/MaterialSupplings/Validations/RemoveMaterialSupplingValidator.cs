using Application.Features.Materials.Commands.RemoveMaterial;
using Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Validations
{
    public class RemoveMaterialSupplingValidator : AbstractValidator<RemoveMaterialCommandRequest>
    {
        public RemoveMaterialSupplingValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Material suppling id is required is requierd")
                .NotNull()
                .WithMessage("Material suppling id is required is requierd");
        }
    }
}
