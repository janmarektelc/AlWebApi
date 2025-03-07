using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace AlWebApi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var useMockData = builder.Configuration.GetValue<bool>("UseMockData");

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt => opt.SuppressMapClientErrors = true);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                })
                .AddApiExplorer(
                options =>
                {
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            if (useMockData)
            {
                builder.Services.AddSingleton<IMainDbRepository, MainDbRepositoryMock>();
            }
            else
            {
                builder.Services.AddDbContext<MainDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbConnection"));
                });
                builder.Services.AddTransient<IMainDbRepository, MainDbRepository>();
                builder.Services.AddTransient<DbInitialiser>();
            }

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var descriptions = app.DescribeApiVersions();
                    foreach (var description in descriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            //app.UseAuthorization();

            app.MapControllers();

            if (!useMockData)
            {
                // Create the database if it doesn't exist, and seed data if it's empty.
                using (var scope = app.Services.CreateScope())
                {
                    var initialiser = scope.ServiceProvider.GetRequiredService<DbInitialiser>();
                    initialiser.UpdateDb().Wait();
                    initialiser.Seed().Wait();
                }
            }

            app.Run();
        }
    }
}
