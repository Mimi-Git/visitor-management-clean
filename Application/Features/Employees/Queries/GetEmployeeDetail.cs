using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public static class GetEmployeeDetail
    {
        public record Query(int Id) : IRequest<EmployeeDto>;

        public class Handler : IRequestHandler<Query, EmployeeDto>
        {
            private readonly IAsyncRepository<Employee> _employeeRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<EmployeeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);

                return _mapper.Map<EmployeeDto>(employee);
            }
        }
    }
}