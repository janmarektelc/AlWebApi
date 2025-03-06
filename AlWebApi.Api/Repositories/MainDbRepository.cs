using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.Repositories
{
    /// <summary>
    /// Main database repository.
    /// </summary>
    public class MainDbRepository : RepositoryBase<MainDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainDbRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Main database context.</param>
        public MainDbRepository(MainDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Adds a product to the database.
        /// </summary>
        /// <param name="product">Product to add.</param>
        public void AddProduct(Product product)
        {
            this.DbContext.Products.Add(product);
        }

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns all products.</returns>
        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await this.DbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
