using System;

namespace Application.Features.Visits
{
    public class VisitDto
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int VisitorId { get; set; }
        public int EmployeeId { get; set; }
    }
}