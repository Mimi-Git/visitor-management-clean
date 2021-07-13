using Application.Responses;

namespace Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandResponse : BaseResponse
    {
        public CreateEmployeeCommandResponse() : base()
        {
        }

        public EmployeeDto Employee { get; set; }
    }
}