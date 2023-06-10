using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Domain.Dummies;

namespace SaaV.Clean.Infrastructure.Persistence
{
    public class CleanDbContext : DbContext
    {
        private readonly ICredentialProvider? _credentialProvider;

        public CleanDbContext(DbContextOptions<CleanDbContext> options, ICredentialProvider? credentialProvider) : base(options)
        {
            _credentialProvider = credentialProvider;
        }

        #region DbSets
        public virtual DbSet<Dummy> Dummies { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Global Conventios
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
               
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    if (property.ClrType.Equals(typeof(DateTime))) property.SetColumnType("datetime");
                    else if (property.ClrType.Equals(typeof(decimal))) property.SetColumnType("decimal(10,2)");
                    else if (property.ClrType.Equals(typeof(string)))
                    {
                        property.IsNullable = false;
                        property.SetMaxLength(255);
                        property.SetIsUnicode(true);
                    }
                }
            }
            #endregion

            #region Entities
            modelBuilder
                .Entity<Dummy>()
                .HasQueryFilter(dummy => !dummy.IsDeleted && dummy.TenantId == _credentialProvider!.Credential.TenantId);
            #endregion
        }
    }
}
