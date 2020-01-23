using AssecorTask.Persistance;
using AssecorTask.Persistance.EF;
using AssecorTask.Persistance.EF.Initialization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AsscorTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AssecorTaskDbContext>();
                context.Database.EnsureCreated();

                AssecorTaskInitializer.Initialize(context);
            }

            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
