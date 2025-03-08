using AlWebApi.Api.Entities;
using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;

namespace AlWebApi.Api.Repositories
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
        /// Gets products from the database with pagination.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns></returns>
        public Task<IEnumerable<Product>> GetProducts(uint pageNumber, uint pageSize, CancellationToken cancellationToken)
        {
            PagingHelper.ValidateProductPageNumberAndPageSize(pageNumber, pageSize);

            return Task.FromResult(products.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize));
        }

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
