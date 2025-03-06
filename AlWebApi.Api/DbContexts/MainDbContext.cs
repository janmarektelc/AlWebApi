using AlWebApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.DbContexts
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to query and save
    /// instances of your entities. DbContext is a combination of the Unit Of Work and Repository patterns.
    /// </summary>
    public class MainDbContext : DbContext
    {
        /// <summary>
        /// A db set of the <see cref="Product"/> classes.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainDbContext" /> class using the specified options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
