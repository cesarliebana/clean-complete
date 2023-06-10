namespace SaaV.Clean.Application.Shared.ValueObjects
{
    public record struct Credential(string UserId, string UserName, int TenantId);
}
