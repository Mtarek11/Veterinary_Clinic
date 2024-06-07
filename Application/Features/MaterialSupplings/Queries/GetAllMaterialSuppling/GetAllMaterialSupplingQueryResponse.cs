using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling
{
    public record GetAllMaterialSupplingQueryResponse
    {
        public string? Id { get; set; }
        public string? MaterialName { get; set; }
        public double SupplyCount { get; set; }
        public double SupplyPrice { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
