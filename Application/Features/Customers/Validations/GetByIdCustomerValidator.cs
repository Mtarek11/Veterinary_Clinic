using Application.Features.Customers.Queries.GetByIdCustomer;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Validations
{
    public class GetByIdCustomer : AbstractValidator<GetByIdCustomerQueryRequest>
    {
        public GetByIdCustomer()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is requierd")
                .NotNull()
                .WithMessage("Id is requierd");

        }
    }
}
