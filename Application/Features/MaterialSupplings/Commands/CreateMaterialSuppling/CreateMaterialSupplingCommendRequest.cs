using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling
{
    public record CreateMaterialSupplingCommendRequest : IRequest<CreateMaterialSupplingCommandResponse>
    {
        public string? MaterialId { get; set; }
        public double SupplyCount { get; set; }
        public DateTime SupplyDate { get; set; }
        public double SupplyPrice { get; set; }
    }
}
