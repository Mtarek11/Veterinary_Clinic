using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Queries.GetAllTreatments
{
    public record GetAllTreatmentsQueryResponse
    {
        public string? Name { get; set; }
        public double Coast { get; set; }
    }
}
