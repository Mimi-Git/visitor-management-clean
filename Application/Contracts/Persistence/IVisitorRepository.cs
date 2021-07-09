using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IVisitorRepository : IAsyncRepository<Visitor>
    {
        Task<Visitor> GetVisitorByEmailAsync(string email);
    }
}