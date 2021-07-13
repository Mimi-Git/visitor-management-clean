using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateEmployeeCommandResponse();

            var validator = new CreateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                var command = _mapper.Map<Employee>(request);
                command = await _employeeRepository.CreateAsync(command);
                response.Employee = _mapper.Map<EmployeeDto>(command);
            }

            return response;
        }
    }
}