using System;
using Xunit;

namespace AdminToolsTests
{
    public class UnitTest1
    {
        readonly DbContextOptions<Cinephiliacs_UserContext> options = new DbContextOptionsBuilder<Cinephiliacs_UserContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

        [Fact]
        public void Test1()
        {
            using (var context = new Cinephiliacs_UserContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            using (var context1 = new Cinephiliacs_UserContext(options))
            {
                context1.Database.EnsureCreated();
            }

        }
    }
}
