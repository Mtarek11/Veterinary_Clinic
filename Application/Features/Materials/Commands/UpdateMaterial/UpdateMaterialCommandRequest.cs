using Application.Features.Customers.Commands.CreateCustomer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.UpdateMaterial
{
    public record UpdateMaterialCommandRequest : IRequest<UpdateMaterialCommandResponse>
    {
        public string? Id {  get; set; }
        public string? Name { get; set; }
    }
}
