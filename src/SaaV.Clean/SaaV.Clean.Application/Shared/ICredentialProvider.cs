using SaaV.Clean.Application.Shared.ValueObjects;

namespace SaaV.Clean.Application.Shared.Interfaces
{
    public interface ICredentialProvider
    {
        public Credential Credential { get; }
    }
}
