using JobPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobPortal.Tests
{
    public class DemoTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public async Task CustomerIntegrationTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);

            var context =  new CustomerContext(optionsBuilder.Options);
        }
    }
}