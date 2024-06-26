﻿using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RefreshTokenUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="loginUserCommandRequest"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest) => Ok(await _mediator.Send(loginUserCommandRequest));

        /// <summary>
        /// Refresh User Token
        /// </summary>
        /// <param name="refreshTokenUserReqeust"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenUserReqeust refreshTokenUserReqeust) => Ok(await _mediator.Send(refreshTokenUserReqeust));
    }
}
