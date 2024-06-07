using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling
{
    public record CreateMaterialSupplingCommandResponse
    {
        public string? Message { get; set; }
    }
}
