using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public static class GetEmployeesList
    {
        public record Query() : IRequest<List<EmployeeDto>>;

        public class Handler : IRequestHandler<Query, List<EmployeeDto>>
        {
            private readonly IAsyncRepository<Employee> _employeeRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Employee> employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<List<EmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var allEmployees = (await _employeeRepository.GetAllAsync()).OrderBy(e => e.LastName);

                return _mapper.Map<List<EmployeeDto>>(allEmployees);
            }
        }
    }
}