using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetShop.Core.Application_Service;
using Easv.PetShop.Core.Application_Service.Impl;
using Easv.PetShop.Core.Application_Service.Service;
using Easv.PetShop.Core.Domain_Service;
using Easv.PetShop.Core.Entity;
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
            
            JwtSecurityKey.SetSecret("a secret that needs to be at least 16 characters long");
           
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        //copied from Lars to get started with Azure
        public void ConfigureServices(IServiceCollection services)
        {
           
            
            //Add CORS
            services.AddCors();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            

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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            

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
                    
                    //DBInitializor.SeedDB(ctx);    
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            //Enable CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseCors(b => b.WithOrigins("http://localhost:5000").AllowAnyMethod());
            
            app.UseAuthentication();

            
            app.UseMvc();
        }
    }
}
