using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Domain.Dummies
{
    public class Dummy: Entity
    {
        public string Name { get; private set; }

        public Dummy(string name, int tenantId, string createdUserId, string createdUserName): base(tenantId, createdUserId, createdUserName)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
