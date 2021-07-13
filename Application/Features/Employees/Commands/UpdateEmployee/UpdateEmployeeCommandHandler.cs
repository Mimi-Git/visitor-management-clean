using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeToUpdate = await _employeeRepository.GetByIdAsync(request.Id);

            if (employeeToUpdate == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            var validator = new UpdateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, employeeToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

            await _employeeRepository.UpdateAsync(employeeToUpdate);

            return Unit.Value;
        }
    }
}