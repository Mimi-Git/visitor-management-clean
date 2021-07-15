using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VisitorRepository : BaseRepository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(VisitorAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Visitor> GetVisitorByEmailAsync(string email)
        {
            return await _dbContext.Visitors.Include(v => v.Visits)
                                            .FirstOrDefaultAsync(v => v.Email == email);
        }
    }
}