using Akmit.DataAccess.Contexts;
using Akmit.Shared.Automapper;
using AutoMapper;
using Akmit.Shared.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Akmit.DataAccess.Interfaces;
using Akmit.BusinessLogic.Interfaces;
using Akmit.BusinessLogic.Services;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace Akmit
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
            services.AddAutoMapper(typeof(MicroserviceProfile));

            services.AddDbContext<IAkmitContext, AkmitContext>(p =>
                p.UseSqlite("Data Source=database.db; Foreign Keys=True"));
            services.AddDbContext<AkmitContext>(p =>
                p.UseSqlite("Data Source=database.db; Foreign Keys=True"));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IDayService, DayService>();
            services.AddScoped<ILessonService, LessonService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Akmit API",
                    Version = "v1",
                    Description = "Описание akmit api",
                    Contact = new OpenApiContact
                    {
                        Name = "AcruxTech",
                        Email = "admin@akmit.ru",
                        Url = new Uri("https://akmit.ru/"),
                    },
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;   //!!!
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = false,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Akmit API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(option => option.WithOrigins("http://localhost:8080", "https://akmit.ru")
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials());

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
               ForwardedHeaders = ForwardedHeaders.XForwardedFor |
               ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseAuthorization();

            using var scope = app.ApplicationServices.CreateScope();

            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            var dbContext = scope.ServiceProvider.GetRequiredService<AkmitContext>();
            dbContext.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
