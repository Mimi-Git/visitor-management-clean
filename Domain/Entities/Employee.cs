using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee : Person
    {
        public string Department { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
    }
}