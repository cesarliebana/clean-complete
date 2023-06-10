using SaaV.Clean.Domain.Dummies;

namespace SaaV.Clean.Application.Dummies.Responses
{
    public record struct GetDummyResponse(int Id, string Name, DateTime ModifiedDateTime);
    public record struct GetAllDummiesResponse(IList<DummyItem> Dummies);
}
