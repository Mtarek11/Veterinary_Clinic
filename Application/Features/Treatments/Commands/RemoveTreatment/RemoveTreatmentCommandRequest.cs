using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Treatments.Commands.RemoveTreatment
{
    public record RemoveTreatmentCommandRequest : IRequest<RemoveTreatmentCommandResponse>
    {
        public string? Id { get; set; }
    }
}
