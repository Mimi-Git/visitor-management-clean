using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Visit : AuditableEntity
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int? VisitorId { get; set; }
        public int? EmployeeId { get; set; }
        public Visitor Visitor { get; set; }
        public Employee Employee { get; set; }
    }
}