using Acme.Business.Manager;
using Acme.Business.Manager.Impl;
using Acme.Data.Models;
using Acme.Data.Repository;
using Acme.Data.Repository.Impl;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:4200"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // services.AddDbContext<AcmeContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            services.AddDbContext<AcmeContext>(options => options.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Acme;Trusted_Connection=True;"));

            // Add Automapper
            services.AddAutoMapper();

            // Instantiate Business and Repository classes
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAddressManager, AddressManager>();
            services.AddTransient<IInvestorManager, InvestorManager>();
            services.AddTransient<IInvestorRepository, InvestorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowMyOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
