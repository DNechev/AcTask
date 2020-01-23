using AssecorTask.Application.Interfaces;
using AssecorTask.Domain;
using AssecorTask.Persistance.CSV.Repositories;
using AssecorTask.Persistance.EF;
using AssecorTask.Persistance.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssecorTask.Persistance.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AssecorTaskDbContext>(optionsBuilder =>
               optionsBuilder.UseSqlServer(configuration.GetConnectionString("AssecorTaskDbConnection")))
                .AddTransient(typeof(IAsyncRepository<>), typeof(EFRepository<>)) //Comment this line in order to test CSV Persistance and uncomment the two lines under it
                //.AddTransient<IAsyncRepository<ColorEntity>, ColorRepository>() //Comment this line in order to test EF Persistance and uncomment the one above it
                //.AddTransient<IAsyncRepository<PersonEntity>, PersonRepository>() //Comment this line in order to test EF Persistance and uncomment the second one above it
                .AddTransient<IData, AssecorTaskData>();
        }
    }
}
