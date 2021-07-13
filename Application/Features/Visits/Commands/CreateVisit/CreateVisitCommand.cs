using MediatR;
using System;

namespace Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommand : IRequest<CreateVisitCommandResponse>
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int VisitorId { get; set; }
        public int EmployeeId { get; set; }
    }
}