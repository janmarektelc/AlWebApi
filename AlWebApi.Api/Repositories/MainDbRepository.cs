using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Entities;
using AlWebApi.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.Repositories
{
    /// <summary>
    /// Main database repository.
    /// </summary>
    public class MainDbRepository : RepositoryBase<MainDbContext>, IMainDbRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainDbRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Main database context.</param>
        public MainDbRepository(MainDbContext dbContext) : base(dbContext)
        {
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

        /// <summary>
        /// Gets a product by its id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns product or null if product is not found.</returns>
        public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await this.DbContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        /// <summary>
        /// Updates a product in the database.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="description">New product description.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns updated product.</returns>
        public async Task<Product?> UpdateProductDescription(int productId, string? description, CancellationToken cancellationToken)
        {
            var product = await this.DbContext.Products.FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
            if (product == null)
            {
                return null;
            }
            product.Description = description;
            await this.DbContext.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
