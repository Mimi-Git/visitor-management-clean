using Application.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEmployeesToCsv(List<EmployeeDto> employeeExportDtos);
    }
}