using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.RemoveCustomer
{
    public record RemoveCustomerCommandRequest : IRequest<RemoveCustomerCommandResponse>
    {
        public string? Id { get; set; }
    }
}
