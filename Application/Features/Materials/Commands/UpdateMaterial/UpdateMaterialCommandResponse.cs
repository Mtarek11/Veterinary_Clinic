using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Materials.Commands.UpdateMaterial
{
    public record UpdateMaterialCommandResponse
    {
        public string? Message { get; set; }
    }
}
