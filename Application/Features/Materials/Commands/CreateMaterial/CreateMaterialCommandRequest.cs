using Application.Features.Materials.Commands.CreateMaterial;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.CreateMaterial
{
    public record CreateMaterialCommandRequest : IRequest<CreateMaterialCommandResponse>
    {
        public string? Name { get; set; }
    }
}
