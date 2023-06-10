using Microsoft.EntityFrameworkCore;
using SaaV.Clean.Domain.Shared;
using SaaV.Clean.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace SaaV.Clean.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CleanDbContext _dbContext;

        public Repository(CleanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IRepository
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Set<T>().AnyAsync(entity => entity.Id == id);
        }

        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _dbContext.Set<T>().Where(filterExpression).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
