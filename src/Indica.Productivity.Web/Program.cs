using Indica.Productivity.Application;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Application.Mappers;
using Indica.Productivity.Application.Services;
using Indica.Productivity.Domain;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Infra;
using Indica.Productivity.Infra.Repositories;
using Indica.Productivity.Shared;
using Indica.Productivity.Shared.Interfaces;
using Indica.Productivity.Web.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Indica.Productivity.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            builder.Services.AddRazorPages().AddViewLocalization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI
            // at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US")
                };

                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0,
                    new QueryStringRequestCultureProvider());
            });

            // AutoMapper
            // Add at least only one assembly reference,
            // and all others will be automatically loaded.
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = config["AutoMapper:LicenseKey"];
                cfg.AddMaps(typeof(ContractAutoMapper));
            });

            #region DATABASE
            if (builder.Environment.IsProduction())
            {
                // Postgres
                builder.Services.AddDbContext<ProductivityContext>(options =>
                {
                    options.UseNpgsql(config.GetConnectionString("Default"));
                    options.UseLazyLoadingProxies();
                });
            }
            else
            {
                // Sqlite3
                builder.Services.AddDbContext<ProductivityContext>(options =>
                {
                    options.UseSqlite("Data Source=TestsResults.db");
                    options.UseLazyLoadingProxies();
                    options.LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging();
                });
            }
            #endregion

            #region SERVICES
            builder.Services.AddScoped<IFileParser, FileParser>();
            // Use Scrutor to register services, but limit the assemblies we scan
            // to avoid accidentally picking up framework/internal types (for example
            // DataProtection's FileSystemXmlRepository/RegistryXmlRepository) which
            // would register "Repository" types that require special ctor dependencies.
            // Register only our application's Service/Repository implementations.
            // We'll scan the application's assemblies and register only classes that
            // inherit from BaseService<,> (for services) and BaseRepository<> (for
            // repositories). This avoids picking up framework/internal "Repository"
            // types as before.
            builder.Services.Scan(scan => scan
                .FromAssembliesOf(typeof(EmployerService), typeof(EmployerRepository), typeof(Program))
                // Services: concrete types that inherit BaseService<,>
                .AddClasses(classes => classes.Where(type => !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseService<,>))
                )).AsImplementedInterfaces().WithScopedLifetime()
                // Repositories: concrete types that inherit BaseRepository<>
                .AddClasses(classes => classes.Where(type => !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))
                )).AsImplementedInterfaces().WithScopedLifetime()
            );

            #endregion

            builder.Services.AddJwtAuthentication(config);

            builder.Services.AddAuthorization();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios.
                // For more information, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseRequestLocalization();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}
