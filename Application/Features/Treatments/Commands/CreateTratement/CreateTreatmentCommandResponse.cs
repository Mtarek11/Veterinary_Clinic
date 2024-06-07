using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.CreateTratement
{
    public record CreateTreatmentCommandResponse
    {
        public string? Message { get; set; }
    }
}
