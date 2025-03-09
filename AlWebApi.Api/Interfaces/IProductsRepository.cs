using AlWebApi.Api.Entities;

namespace AlWebApi.Api.Interfaces
{
    /// <summary>
    /// Products repository.
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Gets a product by its id.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns product or null if product is not found.</returns>
        Task<Product?> GetProductById(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns all products.</returns>
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Gets products from the database with pagination.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts(uint pageNumber, uint pageSize, CancellationToken cancellationToken);

        /// <summary>
        /// Updates a product in the database.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="description">New product description.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns updated product.</returns>
        Task<Product?> UpdateProductDescription(int productId, string? description, CancellationToken cancellationToken);
    }
}
