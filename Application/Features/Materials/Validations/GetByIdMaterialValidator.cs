using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Materials.Queries.GetByIdMaterial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Validations
{
    public class GetByIdMaterialValidator : AbstractValidator<GetByIdMaterialQueryRequest>
    {
        public GetByIdMaterialValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id is requierd")
               .NotNull()
               .WithMessage("Id is requierd");
        }
    }
}