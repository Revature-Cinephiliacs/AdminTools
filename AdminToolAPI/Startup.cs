using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using AdminToolAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using AdminToolsLogic.Logic;
using AdminToolsLogic.LogicHelper;
using Repository;

namespace AdminToolAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string corsRule = "rule";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsRule,
                    builder => builder
                    .WithOrigins(
                        "http://20.94.137.143", // deployed angular frontend
                        "http://localhost:4200", // for testing
                        "https://cinephiliacsapp.azurewebsites.net", // deployed frontend
                        "https://cinephiliacs.org" // deployed frontend
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            var myConnString = Configuration.GetConnectionString("Cinephiliacs_Admintools");
            services.AddDbContext<Cinephiliacs_AdmintoolsContext>(options =>

            {
                options.UseSqlServer(myConnString);
            });

            services.AddScoped<AdminRepository>();
            services.AddScoped<ReportingLogic>();
            services.AddScoped<Mapper>();
            // services.AddScoped<>();

            // for authentication
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "scheme";
            })
            .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>(
                "scheme", o => { });

            // "loggedin"  for signed in if needed
            var permissions = new[] {
                "manage:forums", // for moderator (is signed in)
                "manage:awebsite", // for admin (is moderator and signed in)
            };
            services.AddAuthorization(options =>
            {
                for (int i = 0; i < permissions.Length; i++)
                {
                    options.AddPolicy(permissions[i], policy => policy.RequireClaim(permissions[i], "true"));
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminToolAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminToolAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(corsRule);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
