using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Entities;
using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.Repositories
{
    /// <summary>
    /// Products repository.
    /// </summary>
    public class PrudctsRepository : RepositoryBase<MainDbContext>, IProductsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrudctsRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Main database context.</param>
        public PrudctsRepository(MainDbContext dbContext) : base(dbContext)
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
        /// Gets products from the database with pagination.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts(uint pageNumber, uint pageSize, CancellationToken cancellationToken)
        {
            PagingHelper.ValidateProductPageNumberAndPageSize(pageNumber, pageSize);

            return await this.DbContext.Products.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize).ToListAsync(cancellationToken);
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
