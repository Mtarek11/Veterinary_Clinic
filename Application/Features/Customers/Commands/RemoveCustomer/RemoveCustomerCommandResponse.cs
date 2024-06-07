using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.RemoveCustomer
{
    public record RemoveCustomerCommandResponse
    {
        public string? Message { get; set; }
    }
}
