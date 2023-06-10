using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Domain.Dummies
{
    public interface IDummyRepository : IRepository<Dummy>
    {
        Task<List<DummyItem>> GetAllAsync();
    }
}
