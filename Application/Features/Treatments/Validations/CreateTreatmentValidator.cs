using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Treatments.Commands.CreateTratement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Validations
{
    public class CreateTreatmentValidator : AbstractValidator<CreateTreatmentCommandRequest>
    {
        public CreateTreatmentValidator()
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

            RuleFor(x => x.Coast)
                .NotEmpty()
                .WithMessage("Coast is requierd")
                .NotNull()
                .WithMessage("Coast is requierd");
        }
    }
}
