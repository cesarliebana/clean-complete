using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CleanDbContext _dbContext;

        public UnitOfWork(CleanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
