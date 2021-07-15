using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class VisitRepository : BaseRepository<Visit>, IVisitRepository
    {
        public VisitRepository(VisitorAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}