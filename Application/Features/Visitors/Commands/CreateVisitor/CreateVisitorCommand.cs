using MediatR;

namespace Application.Features.Visitors.Commands.CreateVisitor
{
    public class CreateVisitorCommand : IRequest<CreateVisitorCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}