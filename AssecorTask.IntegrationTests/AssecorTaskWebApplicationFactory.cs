using System.Linq;
using AssecorTask.IntegrationTests.Initialization;
using AssecorTask.Persistance.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AssecorTask.IntegrationTests
{
    public class AssecorTaskWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<AssecorTaskDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<AssecorTaskDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AssecorTaskDbContext>();
                    context.Database.EnsureCreated();

                    AssecorTaskTestsInitializer.Initialize(context);
                }
            });
        }
    }
}
