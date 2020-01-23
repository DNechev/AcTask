using System.Reflection;
using AsscorTask.Mapper;
using AssecorTask.Application.Mapper;
using AssecorTask.Application.Services;
using AssecorTask.Persistance.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsscorTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IPersonService, PersonService>()
                .AddAutoMapper(typeof(PersonEntityToPersonServiceModelProfile).GetTypeInfo().Assembly,
                    typeof(PersonServiceModelToPersonViewModel).GetTypeInfo().Assembly)
                .RegisterPersistance(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
