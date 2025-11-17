
using EsportsCmsApplication;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Services;
using EsportsCmsDomain.Entities;
using EsportsCmsInfrastructure;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using EsportsCmsDomain.EntitiesNew;

namespace EsportsCmsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EsportsCmsDomain.EntitiesNew.EsportsCmsContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DbContext"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                ).EnableSensitiveDataLogging()
                 .EnableDetailedErrors();
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);
            builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();
            builder.Services.AddScoped<ICollegeService, CollegeService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });

            });

            var app = builder.Build();


            app.UseCors("default");
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
