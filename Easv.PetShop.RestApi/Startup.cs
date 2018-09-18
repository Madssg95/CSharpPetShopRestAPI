using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application_Service;
using Easv.PetShop.Core.Application_Service.Impl;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Infrastructure.SQLDB;
using Easv.PetShop.Infrastructure.SQLDB.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Easv.PetShop.RestApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get;  }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //not a real sql db, but acts like one 
            /*
            services.AddDbContext<PetShopContext>(
                opt => opt.UseInMemoryDatabase("database")
                );
             */

            services.AddDbContext<PetShopContext>(
                opt => opt.UseSqlite("Data Source = PetShop.db")
            );
            
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    DBInitializor.SeedDB(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
