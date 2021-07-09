using System.Collections.Generic;

namespace Domain.Entities
{
    public class Visitor : Person
    {
        public IEnumerable<Visit> Visits { get; set; }
    }
}