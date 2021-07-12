using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IVisitRepository : IAsyncRepository<Visit>
    {
    }
}