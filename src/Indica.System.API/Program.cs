using Indica.System.Application.Interfaces;
using Indica.System.Application.Mappers;
using Indica.System.Application.Services;
using Indica.System.Domain.Interfaces;
using Indica.System.Infra;
using Indica.System.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Indica.System.API
{
	public static class Program
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
            builder.Services.AddAutoMapper(
                typeof(ContractAutoMapper).Assembly,
                typeof(SupervisorAutoMapper).Assembly,
                typeof(ElectricianAutoMapper).Assembly
            );

            #region DATABASE
            // InMemory
            builder.Services.AddDbContext<ProductivityContext>(options =>
                options.UseInMemoryDatabase(databaseName: "productivity"));
            // SQLite
            // builder.Services.AddDbContext<ProductivityContext>(options =>
            //      options.UseSqlite("Data Source=productivity.db"));
            // Postgres
            // builder.Services.AddDbContext<ProductivityContext>(options =>
            //      options.UseNpgsql(config.GetConnectionString("Default")));
            #endregion

            #region SERVICES
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<ISupervisorService, SupervisorService>();
            builder.Services.AddScoped<IElectricianService, ElectricianService>();
            #endregion

            #region REPOSITORIES
            builder.Services.AddScoped<IContractRepository, ContractRepository>();
            builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();
            builder.Services.AddScoped<IElectricianRepository, ElectricianRepository>();
            #endregion

            WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

            app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}