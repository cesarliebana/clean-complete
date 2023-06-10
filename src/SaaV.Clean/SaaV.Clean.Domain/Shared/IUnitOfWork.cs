namespace SaaV.Clean.Domain.Shared
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
