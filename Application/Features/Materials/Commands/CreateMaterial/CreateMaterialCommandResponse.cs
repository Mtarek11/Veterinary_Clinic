using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.CreateMaterial
{
    public record CreateMaterialCommandResponse
    {
        public string? Message { get; set; }
    }
}