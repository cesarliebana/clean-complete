using Bogus;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Application.Shared.ValueObjects;

namespace SaaV.Clean.UnitTest.Providers
{
    public class CredentialProvider : ICredentialProvider
    {
        public Credential Credential 
        {
            get
            {
                Faker faker = new("es");
                return new Credential(
                    Guid.NewGuid().ToString(),
                    $"{faker.Name.FirstName()}.{faker.Name.LastName}",
                    1);
            } 
        }
    }
}

      
