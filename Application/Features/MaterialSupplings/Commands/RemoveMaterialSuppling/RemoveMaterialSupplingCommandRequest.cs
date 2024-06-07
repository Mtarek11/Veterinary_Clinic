using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Commands.RemoveMaterialSuppling
{
    public record RemoveMaterialSupplingCommandRequest : IRequest<RemoveMaterialSupplingCommandResponse>
    {
        public string? Id { get; set; }
    }
}
