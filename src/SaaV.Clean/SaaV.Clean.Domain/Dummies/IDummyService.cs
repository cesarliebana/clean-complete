namespace SaaV.Clean.Domain.Dummies
{
    public interface IDummyService
    {
        Task<List<DummyExternalItem>> GetExternalItemsAsync();
    }
}
