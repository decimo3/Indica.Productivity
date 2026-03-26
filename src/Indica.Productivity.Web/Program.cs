using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Application.Mappers;
using Indica.Productivity.Application.Services;
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
using System.ComponentModel;
using System.Globalization;

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
            // Used Scrutor instead add all services manually
            builder.Services.Scan(scan => scan
                .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
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
