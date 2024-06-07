using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.RemoveCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Materials.Commands.CreateMaterial;
using Application.Features.Materials.Commands.RemoveMaterial;
using Application.Features.Materials.Commands.UpdateMaterial;
using Application.Features.Materials.Queries.GetAllMateria;
using Application.Features.Materials.Queries.GetByIdMaterial;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /// <summary>
        /// Create material
        /// </summary>
        /// <param name="createMaterialCommandRequest"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateMaterialCommandRequest createMaterialCommandRequest) => Ok(await _mediator.Send(createMaterialCommandRequest));
        /// <summary>
        /// Update material
        /// </summary>
        /// <param name="updateMaterialCommandRequest"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateMaterialCommandRequest updateMaterialCommandRequest) => Ok(await _mediator.Send(updateMaterialCommandRequest));
        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <param name="getAllCustomerQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMaterialQueryRequest getAllMaterialQueryRequest) => Ok(await _mediator.Send(getAllMaterialQueryRequest));
        /// <summary>
        /// Get material by id
        /// </summary>
        /// <param name="getByIdMaterialQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdMaterialQueryRequest getByIdMaterialQueryRequest) => Ok(await _mediator.Send(getByIdMaterialQueryRequest));
        /// <summary>
        /// Remove material
        /// </summary>
        /// <param name="removeMaterialCommandRequest"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove([FromQuery] RemoveMaterialCommandRequest removeMaterialCommandRequest) => Ok(await _mediator.Send(removeMaterialCommandRequest));
    }
}
