using JobPortal.Controllers;
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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);

            var context =  new CustomerContext(optionsBuilder.Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            //context.Customers.RemoveRange(await context.Customers.ToArrayAsync());
            //await context.SaveChangesAsync();

            var controller = new CustomerController(context);

            await controller.Add(new Customer() { CustomerName = "FooBar" });

            var result = await controller.GetAll();
            Assert.Single(result);
            Assert.Equal("FooBar", result.First().CustomerName);
        }
    }
}