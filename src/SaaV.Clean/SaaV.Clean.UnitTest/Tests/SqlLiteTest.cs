using Microsoft.EntityFrameworkCore;
using SaaV.Clean.Infrastructure.Persistence;

namespace SaaV.Clean.UnitTest.Tests
{
    public class SqlLiteTest
    {
        public SqlLiteTest(CleanDbContext dbContext)
        {
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
        }
    }
}