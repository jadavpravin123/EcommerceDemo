using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Data.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerce.WebApi
{
    public class Startup
    {
        private const string PortalName = "E Commerce";
        private const string Version1 = "V1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            services.AddDbContext<ECommerceDBContext>(options =>
                                options.UseSqlServer(appConfiguration.SqlConnectonString));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(Version1, new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = Version1,
                    Title = PortalName,
                    Description = $"{PortalName} v1 APIs",
                });

            });
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });
            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            services.AddDistributedMemoryCache();
            services.AddSession();
            AppConfiguration appseting = new AppConfiguration();
            services.AddDistributedSqlServerCache(options => {
                options.ConnectionString = appseting.SqlConnectonString;
                options.SchemaName = "dbo";
                options.TableName = "MyCache";
                options.DefaultSlidingExpiration = TimeSpan.FromMinutes(1440);

            });
           
            StructureMapper.InitializeStructureMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string[] Parameters = { "http://localhost:1100", "http://localhost:4200" };
            app.UseCors(x => x
            .WithOrigins(Parameters)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseStaticFiles();

            //enable session before MVC
            app.UseSession();

            app.UseRequestResponseLogging();

            app.UseHttpsRedirection();

            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=sample}/{action=Index}/{id?}");
            });
            app.UseSwagger();

            // Enable middle ware to serve swagger-ui (HTML, JS, CSS, etc.),  r
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{Version1}/swagger.json", Version1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
            });
        }
    }
}
