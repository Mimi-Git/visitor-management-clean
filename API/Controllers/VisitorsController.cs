using Application.Features.Visitors;
using Application.Features.Visitors.Commands.CreateVisitor;
using Application.Features.Visitors.Commands.DeleteVisitor;
using Application.Features.Visitors.Commands.UpdateVisitor;
using Application.Features.Visitors.Dtos;
using Application.Features.Visitors.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VisitorDto>>> GetAllVisitors()
        {
            var dtos = await _mediator.Send(new GetVisitorsList.Query());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetVisitorById")]
        public async Task<ActionResult<VisitorDto>> GetVisitorById(int id)
        {
            var getVisitorDetailQuery = new GetVisitorDetail.Query(id);
            return Ok(await _mediator.Send(getVisitorDetailQuery));
        }

        [HttpGet("getbyemail/{email}", Name = "GetVisitorByEmail")]
        public async Task<ActionResult<VisitorWithVisitsDto>> GetVisitorByEmail(string email)
        {
            var getVisitorByEmailQuery = new GetVisitorByEmailWithVisits.Query(email);
            return Ok(await _mediator.Send(getVisitorByEmailQuery));
        }

        [HttpPost]
        public async Task<ActionResult<CreateVisitorCommandResponse>> CreateVisitor([FromBody] CreateVisitorCommand createVisitorCommand)
        {
            var response = await _mediator.Send(createVisitorCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateVisitor(int id, [FromBody] UpdateVisitorCommand updateVisitorCommand)
        {
            await _mediator.Send(updateVisitorCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            await _mediator.Send(new DeleteVisitorCommand() { Id = id });
            return NoContent();
        }
    }
}