
using EsportsCmsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace EsportsCmsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EsportsCmsContext>(options =>
            {
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("DbContext"),
                providerOptions => providerOptions.EnableRetryOnFailure()
                ).EnableSensitiveDataLogging().EnableDetailedErrors();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("My Esports API :");
                    options.WithTheme(ScalarTheme.Mars);

                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
