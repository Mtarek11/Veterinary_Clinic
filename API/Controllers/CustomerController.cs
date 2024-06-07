using Application.Features.Customers.Queries.GetAllArticle;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Customers.Commands.RemoveCustomer;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="createCustomerCommandRequest"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommandRequest createCustomerCommandRequest) => Ok(await _mediator.Send(createCustomerCommandRequest));
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="updateCustomerCommandRequest"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest) => Ok(await _mediator.Send(updateCustomerCommandRequest));
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="getAllCustomerQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest) => Ok(await _mediator.Send(getAllCustomerQueryRequest));
        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="getByIdCustomerQueryRequest"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest) => Ok(await _mediator.Send(getByIdCustomerQueryRequest));
        /// <summary>
        /// Remove customer
        /// </summary>
        /// <param name="removeCustomerCommandRequest"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove([FromQuery] RemoveCustomerCommandRequest removeCustomerCommandRequest) => Ok(await _mediator.Send(removeCustomerCommandRequest));
    }
}
