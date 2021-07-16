using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public static class GetEmployeesExport
    {
        public record Query() : IRequest<EmployeeExportFileVm>;

        public class Handler : IRequestHandler<Query, EmployeeExportFileVm>
        {
            private readonly IAsyncRepository<Employee> _employeeRepository;
            private readonly IMapper _mapper;
            private readonly ICsvExporter _csvExporter;

            public Handler(IAsyncRepository<Employee> employeeRepository, IMapper mapper, ICsvExporter csvExporter)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
                _csvExporter = csvExporter;
            }

            public async Task<EmployeeExportFileVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var allEmployees = _mapper.Map<List<EmployeeDto>>((await _employeeRepository.GetAllAsync()).OrderBy(e => e.LastName));

                var fileData = _csvExporter.ExportEmployeesToCsv(allEmployees);

                var employeeExportFileDto = new EmployeeExportFileVm() { ContentType = "text/csv", Data = fileData, EmployeeFileName = $"{Guid.NewGuid()}.csv" };

                return employeeExportFileDto;
            }
        }
    }
}