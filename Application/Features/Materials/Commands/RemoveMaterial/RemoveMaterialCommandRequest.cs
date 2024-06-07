using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.RemoveMaterial
{
    public record RemoveMaterialCommandRequest : IRequest<RemoveMaterialCommandResponse>
    {
        public string? Id { get; set; }
    }
}
