using SaaV.Clean.Domain.Dummies;

namespace SaaV.Clean.Infrastructure.Services 
{
    internal class DummyService : IDummyService
    {
        public Task<List<DummyExternalItem>> GetExternalItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
