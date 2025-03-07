using AlWebApi.Api.Entities;
using AlWebApi.Api.Interfaces;

namespace AlWebApi.Api.DbContexts
{
    /// <summary>
    /// Fake implementation of the main database repository.
    /// </summary>
    public class MainDbRepositoryMock : IMainDbRepository
    {
        private List<Product> products;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainDbRepositoryMock"/> class.
        /// </summary>
        public MainDbRepositoryMock()
        {
            products = SeedProducts(150);
        }

        /// <summary>
        /// Gets a product by its id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns product or null if product is not found.</returns>
        public Task<Product?> GetProductById(int id, CancellationToken cancellationToken) => Task.FromResult(products.FirstOrDefault(p => p.Id == id));

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns all products.</returns>
        public Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken) => Task.FromResult<IEnumerable<Product>>(products);

        /// <summary>
        /// Updates a product in the database.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="description">New product description.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns updated product.</returns>
        public Task<Product?> UpdateProductDescription(int productId, string? description, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return Task.FromResult<Product?>(null);
            }
            product.Description = description;

            return Task.FromResult<Product?>(product);
        }

        private List<Product> SeedProducts(int count)
        {
            var products = new List<Product>(count);
            for (int i = 0; i < count; i++)
            {
                products.Add(new Product { Id = i, Name = $"Mock product{i}", Description = $"Mock description{i}", ImgUrl = $"url{i}", Price = i * 10 });
            }

            return products;
        }
    }
}
