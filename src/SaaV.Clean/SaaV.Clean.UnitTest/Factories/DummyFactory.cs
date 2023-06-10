using Bogus;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;

namespace SaaV.Clean.UnitTest.Factories
{
    internal static class DummyFactory
    {
        internal static CreateDummyRequest GetCreateDummyRequest() 
        {
            Faker faker = new("es");
            return new (Name: faker.Name.FullName());
        }

        internal static UpdateDummyRequest GetUpdateDummyRequest(GetDummyResponse getDummyResponse)
        {
            Faker faker = new("es");
            return new(getDummyResponse.Id, faker.Name.FullName());
        }
    }
}
