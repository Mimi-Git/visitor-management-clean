using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IVisitorRepository : IAsyncRepository<Visitor>
    {
        Task<Visitor> GetVisitorByEmailAsync(string email);
    }
}