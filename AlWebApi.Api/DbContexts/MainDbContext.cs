using AlWebApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.DbContexts
{
    public class MainDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
