using Application.Features.Visits;
using System.Collections.Generic;

namespace Application.Features.Visitors.Dtos
{
    public class VisitorWithVisitsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<VisitDto> Visits { get; set; }
    }
}