using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.Helpers
{
    /// <summary>
    /// Database initialiser.
    /// </summary>
    public class DbInitialiser
    {
        private readonly MainDbContext mainDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbInitialiser"/> class.
        /// </summary>
        /// <param name="mainDbContext"></param>
        public DbInitialiser(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        /// <summary>
        /// Updates od creates a database.
        /// </summary>
        /// <returns></returns>
        public async Task UpdateDb()
        {
            await mainDbContext.Database.MigrateAsync();
        }

        /// <summary>
        /// Seeds the database.
        /// </summary>
        /// <returns></returns>
        public async Task Seed()
        {
            if (!mainDbContext.Products.Any())
            {
                for (int i = 1; i < 101; i++)
                {
                    mainDbContext.Products.Add(new Product { Name = $"product{i}", Description = $"description{i}", ImgUrl = $"url{i}", Price = i * 10 });
                }
                await mainDbContext.SaveChangesAsync();
            }
        }
    }
}
