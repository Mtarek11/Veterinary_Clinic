using Application.Features.Customers.Commands.CreateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
    {
        public string? Id {  get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
