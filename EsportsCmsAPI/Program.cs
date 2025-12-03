
using EsportsCmsAPI.Filters;
using EsportsCmsApplication;
using EsportsCmsApplication.DTOValidations;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Services;
using EsportsCmsDomain.Entities;
using EsportsCmsDomain.EntitiesNew;
using EsportsCmsInfrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

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
            DotNetEnv.Env.Load();
            var token = Environment.GetEnvironmentVariable("TOKEN");
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();

            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCollegeValidator>();
            builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();
            builder.Services.AddScoped<ICollegeService, CollegeService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });

            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                    ValidAudience = builder.Configuration["AppSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(token)
            ),
                    ClockSkew = TimeSpan.Zero
                };

            });
            builder.Services.AddScoped<IAuthService, AuthService>();
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
