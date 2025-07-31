using Indica.System.Application.Interfaces;
using Indica.System.Application.Mappers;
using Indica.System.Application.Services;
using Indica.System.Domain.Interfaces;
using Indica.System.Infra;
using Indica.System.Infra.Repositories;
using Indica.System.Shared;
using Indica.System.Shared.Interfaces;
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
            // Add at least only one assemby reference,
            // and all others will be automaticaly loaded.
            builder.Services.AddAutoMapper(typeof(ContractAutoMapper));

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
            builder.Services.AddScoped<IFileParser, FileParser>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<IEmployerService, EmployerService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            // Finishing entity will not exposed in the API, so I don't create a service
            builder.Services.AddScoped<IFinishingPaymentService, FinishingPaymentService>();
            #endregion

            #region REPOSITORIES
            builder.Services.AddScoped<IContractRepository, ContractRepository>();
            builder.Services.AddScoped<IEmployerRepository, EmployerRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            // Finishing entity will not exposed in the API, so I don't create a repository
            builder.Services.AddScoped<IFinishingPaymentRepository, FinishingPaymentRepository>();
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