using MediatR;
using System;

namespace Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int VisitorId { get; set; }
        public int EmployeeId { get; set; }
    }
}