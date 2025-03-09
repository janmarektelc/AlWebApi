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
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var useMockData = builder.Configuration.GetValue<bool>("UseMockData");

            ConfigureBuilder(builder, useMockData);
            var app = builder.Build();

            await ConfigureApp(app, useMockData);
            app.Run();
        }

        private static void ConfigureBuilder(WebApplicationBuilder builder, bool useMockData)
        {
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
                builder.Services.AddSingleton<IProductsRepository, ProductsRepositoryMock>();
            }
            else
            {
                builder.Services.AddDbContext<MainDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbConnection"));
                });
                builder.Services.AddTransient<IProductsRepository, PrudctsRepository>();
                builder.Services.AddTransient<DbInitialiser>();
            }

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        private static async Task ConfigureApp(WebApplication app, bool useMockData)
        {
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
                    await initialiser.UpdateDb();
                    await initialiser.Seed();
                }
            }
        }

    }
}
