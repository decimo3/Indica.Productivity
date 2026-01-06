using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Application.Mappers;
using Indica.Productivity.Application.Services;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Infra;
using Indica.Productivity.Infra.Repositories;
using Indica.Productivity.Shared;
using Indica.Productivity.Shared.Interfaces;
using Indica.Productivity.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Indica.Productivity.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI
			// at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

            // AutoMapper
            // Add at least only one assemby reference,
            // and all others will be automaticaly loaded.
            builder.Services.AddAutoMapper(typeof(ContractAutoMapper));

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

            app.UseHttpsRedirection();

            app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}