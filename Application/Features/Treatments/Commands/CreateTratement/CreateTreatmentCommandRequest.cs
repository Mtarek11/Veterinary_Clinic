using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.CreateTratement
{
    public record CreateTreatmentCommandRequest : IRequest<CreateTreatmentCommandResponse>
    {
        public string? Name { get; set; }
        public double Coast { get; set; }
    }
}
