using Mapster;
using Microsoft.EntityFrameworkCore;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Infrastructure.Persistence;

namespace SaaV.Clean.Infrastructure.Repositories
{
    public class DummyRepository : Repository<Dummy>, IDummyRepository
    {
        public DummyRepository(CleanDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<DummyItem>> GetAllAsync()
        {
            return await _dbContext.Dummies.ProjectToType<DummyItem>().ToListAsync();
        }
    }
}
