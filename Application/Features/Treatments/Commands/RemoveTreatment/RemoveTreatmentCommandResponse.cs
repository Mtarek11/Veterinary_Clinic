using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.RemoveTreatment
{
    public record RemoveTreatmentCommandResponse
    {
        public string? Message { get; set; }
    }
}
