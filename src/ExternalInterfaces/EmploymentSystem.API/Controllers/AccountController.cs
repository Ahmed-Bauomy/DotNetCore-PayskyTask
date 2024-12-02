using EmploymentSystem.Application.Features.User.Commands.SignInUser;
using EmploymentSystem.Application.Features.User.Commands.SignUpUser;
using EmploymentSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmploymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(AuthResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResult>> Register(SignUpUserCommand user)
        {
            return Ok(await _mediator.Send(user));
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(AuthResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResult>> Login(SignInUserCommand user)
        {
            return Ok(await _mediator.Send(user));
        }
    }
}
