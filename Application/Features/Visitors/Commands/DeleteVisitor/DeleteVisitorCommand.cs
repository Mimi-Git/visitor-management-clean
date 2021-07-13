using MediatR;

namespace Application.Features.Visitors.Commands.DeleteVisitor
{
    public class DeleteVisitorCommand : IRequest
    {
        public int Id { get; set; }
    }
}