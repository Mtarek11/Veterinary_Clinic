using Application.Features.Treatments.Commands.RemoveTreatment;
using Application.Features.Treatments.Commands.UpdateTreatment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Validations
{
    public class RemoveTreatmentValidator : AbstractValidator<RemoveTreatmentCommandRequest>
    {
        public RemoveTreatmentValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id is requierd")
               .NotNull()
               .WithMessage("Id is requierd");
        }
    }
}
