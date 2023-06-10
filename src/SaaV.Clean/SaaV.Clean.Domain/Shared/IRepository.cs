using System.Linq.Expressions;

namespace SaaV.Clean.Domain.Shared
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<bool> ExistsAsync(int id);

        Task<IList<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> filterExpression);

        Task<TEntity?> GetByIdAsync(int id);

        void Add(TEntity entity);
    }
}
