﻿using AlWebApi.Api.Entities;

namespace AlWebApi.Api.Interfaces
{
    /// <summary>
    /// Main database repository.
    /// </summary>
    public interface IMainDbRepository
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
        /// Updates a product in the database.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <param name="description">New product description.</param>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>Returns updated product.</returns>
        Task<Product?> UpdateProductDescription(int productId, string? description, CancellationToken cancellationToken);
    }
}
