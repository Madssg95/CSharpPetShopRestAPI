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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Easv.PetShop.RestApi
{
    public class Startup
    {

        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; set; }
        
        public Startup(IConfiguration conf, IHostingEnvironment env)
        {
            _conf = conf;
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
           
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        //copied from Lars to get started with Azure
        public void ConfigureServices(IServiceCollection services)
        {
           
            
            //Add CORS
            services.AddCors();

        if (_env.IsDevelopment())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlite("Data Source=PetShop.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();
            

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
                    
                    DBInitializor.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            //Enable CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod());
            //app.UseCors(b => b.WithOrigins("http://localhost:5000").AllowAnyMethod());
            
            app.UseMvc();
        }
    }
}
