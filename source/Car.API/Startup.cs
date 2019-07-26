using Car.Business;
using Car.Business.Interfaces;
using Car.Domain.Entities;
using Car.Repository;
using Car.Repository.Interfaces;
using Car.Services;
using Car.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Car.API
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
            DependencyInjection(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IRepositoryBase<CarEntity>, RepositoryBase<CarEntity>>();
            services.AddTransient<ICarServices, CarServices>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarBusiness, CarBusiness>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
