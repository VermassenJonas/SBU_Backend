using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SBU_API.Data;
using SBU_API.Data.Repositories;
using SBU_API.Mappers;
using SBU_API.Models;

namespace SBU_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SbuDbContext>(options =>
              options.UseMySQL(Configuration.GetConnectionString("SbuContext")));

            services.AddScoped<SbuDataInitializer>();
            services.AddScoped<MonsterRepository, MonsterRepositoryImpl>();
            services.AddScoped<UserRepository, UserRepositoryImpl>();
            services.AddScoped<MonsterMapper, MonsterMapper>();
            services.AddScoped<UserMapper, UserMapper>();

            services.AddOpenApiDocument(c => {
                c.DocumentName = "apidocs";
                c.Title = "Stat Block API";
                c.Version = "v1";
                c.Description = "The API for Stat Blocks United";
            });

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SbuDataInitializer sbuDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseSwagger();


            sbuDataInitializer.InitializeData();
        }
    }
}
