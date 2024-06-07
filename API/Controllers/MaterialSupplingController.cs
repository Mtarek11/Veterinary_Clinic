using Application.Features.Materials.Commands.CreateMaterial;
using Application.Features.Materials.Commands.RemoveMaterial;
using Application.Features.Materials.Commands.UpdateMaterial;
using Application.Features.Materials.Queries.GetAllMateria;
using Application.Features.Materials.Queries.GetByIdMaterial;
using Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling;
using Application.Features.MaterialSupplings.Commands.RemoveMaterialSuppling;
using Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialSupplingController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /// <summary>
        /// Create material suppling
        /// </summary>
        /// <param name="createMaterialSupplingCommendRequest"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateMaterialSupplingCommendRequest createMaterialSupplingCommendRequest) => Ok(await _mediator.Send(createMaterialSupplingCommendRequest));
        /// <summary>
        /// Get all material supplings
        /// </summary>
        /// <param name="getAllMaterialSupplingQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMaterialSupplingQueryRequest getAllMaterialSupplingQueryRequest) => Ok(await _mediator.Send(getAllMaterialSupplingQueryRequest));
        /// <summary>
        /// Remove material
        /// </summary>
        /// <param name="removeMaterialSupplingCommandRequest"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove([FromQuery] RemoveMaterialSupplingCommandRequest removeMaterialSupplingCommandRequest) => Ok(await _mediator.Send(removeMaterialSupplingCommandRequest));
    }
}
