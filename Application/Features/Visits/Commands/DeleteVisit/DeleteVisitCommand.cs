using MediatR;

namespace Application.Features.Visits.Commands.DeleteVisit
{
    public class DeleteVisitCommand : IRequest
    {
        public int Id { get; set; }
    }
}