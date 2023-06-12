namespace SaaV.Clean.Domain.Dummies
{
    public record struct DummyItem(int Id, string Name);

    public record struct DummyExternalItem(int Id, string Name, byte SourceId);
}
