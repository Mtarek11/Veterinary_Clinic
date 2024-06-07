using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.MaterialSupplings.Commands.CreateMaterialSuppling;
using Application.Features.MaterialSupplings.Commands.RemoveMaterialSuppling;
using Application.Features.MaterialSupplings.Queries.GetAllMaterialSuppling;
using Application.Features.Treatments.Commands.CreateTratement;
using Application.Features.Treatments.Commands.RemoveTreatment;
using Application.Features.Treatments.Commands.UpdateTreatment;
using Application.Features.Treatments.Queries.GetAllTreatments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TreatmentController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /// <summary>
        /// Create treatment
        /// </summary>
        /// <param name="createTreatmentCommandRequest"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateTreatmentCommandRequest createTreatmentCommandRequest) => Ok(await _mediator.Send(createTreatmentCommandRequest));
        /// <summary>
        /// Update treatment
        /// </summary>
        /// <param name="updateTreatmentCommandRequest"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateTreatmentCommandRequest updateTreatmentCommandRequest) => Ok(await _mediator.Send(updateTreatmentCommandRequest));
        /// <summary>
        /// Get all treatments
        /// </summary>
        /// <param name="getAllTreatmentsQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTreatmentsQueryRequest getAllTreatmentsQueryRequest) => Ok(await _mediator.Send(getAllTreatmentsQueryRequest));
        /// <summary>
        /// Remove treatment
        /// </summary>
        /// <param name="removeTreatmentCommandRequest"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove([FromQuery] RemoveTreatmentCommandRequest removeTreatmentCommandRequest) => Ok(await _mediator.Send(removeTreatmentCommandRequest));
    }
}

