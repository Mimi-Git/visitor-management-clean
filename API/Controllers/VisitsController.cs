using Application.Features.Visits;
using Application.Features.Visits.Commands.CreateVisit;
using Application.Features.Visits.Commands.DeleteVisit;
using Application.Features.Visits.Commands.UpdateVisit;
using Application.Features.Visits.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VisitDto>>> GetAllVisits()
        {
            var dtos = await _mediator.Send(new GetVisitsList.Query());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetVisitById")]
        public async Task<ActionResult<VisitDto>> GetVisitById(int id)
        {
            var getVisitDetailQuery = new GetVisitDetail.Query(id);
            return Ok(await _mediator.Send(getVisitDetailQuery));
        }

        [HttpPost]
        public async Task<ActionResult<CreateVisitCommandResponse>> CreateVisit([FromBody] CreateVisitCommand createVisitCommand)
        {
            var response = await _mediator.Send(createVisitCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateVisit(int id, [FromBody] UpdateVisitCommand updateVisitCommand)
        {
            await _mediator.Send(updateVisitCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            await _mediator.Send(new DeleteVisitCommand() { Id = id });
            return NoContent();
        }
    }
}