using Application.Features.Treatments.Commands.CreateTratement;
using Application.Features.Treatments.Commands.UpdateTreatment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Validations
{
    public class UpdateTreatmentValidator : AbstractValidator<UpdateTreatmentCommandRequest>
    {
        public UpdateTreatmentValidator()
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

            RuleFor(x => x.Coast)
                .NotEmpty()
                .WithMessage("Coast is requierd")
                .NotNull()
                .WithMessage("Coast is requierd");
        }
    }
}