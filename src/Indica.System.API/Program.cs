using Indica.System.Application.Interfaces;
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