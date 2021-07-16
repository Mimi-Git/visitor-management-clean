using Application.Features.Employees;
using Application.Features.Employees.Commands.CreateEmployee;
using Application.Features.Employees.Commands.DeleteEmployee;
using Application.Features.Employees.Commands.UpdateEmployee;
using Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            var dtos = await _mediator.Send(new GetEmployeesList.Query());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var getEmployeeDetailQuery = new GetEmployeeDetail.Query(id);
            return Ok(await _mediator.Send(getEmployeeDetailQuery));
        }

        [HttpPost]
        public async Task<ActionResult<CreateEmployeeCommandResponse>> CreateEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            var response = await _mediator.Send(createEmployeeCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            await _mediator.Send(updateEmployeeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
            return NoContent();
        }
    }
}