using EmploymentSystem.Application.Features.Vacancy.Commands.ApplyToVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.CreateVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.DeleteVacancy;
using EmploymentSystem.Application.Features.Vacancy.Commands.UpdateVacancy;
using EmploymentSystem.Application.Features.Vacancy.Queries.GetVacancies;
using EmploymentSystem.Application.Models;
using EmploymentSystem.Domain.Entities;
using EmploymentSystem.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmploymentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VacancyDTO>),(int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VacancyDTO>>> GetVacancies()
        {
            var test = User.Identity.Name;
            var vacancies = await _mediator.Send(new GetVacanciesQuery());
            return Ok(vacancies);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Attributes.Authorize("Employer")]
        public async Task<IActionResult> CreateVacancy(CreateVacancyCommand product)
        {
            var result = await _mediator.Send(product);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Attributes.Authorize("Employer")]
        public async Task<IActionResult> UpdateVacancy(UpdateVacancyCommand product)
        {
            await _mediator.Send(product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Attributes.Authorize("Employer")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            var deleteCommand = new DeleteVacancyCommand(id);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpPost("ApplyToVacancy/{VacancyId:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [Attributes.Authorize("Applicant")]
        public async Task<IActionResult> ApplyToVacancy(int VacancyId)
        {
            var deleteCommand = new ApplyToVacancyCommand()
            {
                VacancyId = VacancyId,
                UserId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value
            };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
