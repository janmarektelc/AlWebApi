using AlWebApi.Api.Entities;
using AlWebApi.Api.Models;

namespace AlWebApi.Api.Helpers
{
    /// <summary>
    /// Helper mapper class.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Map database object product to productDto.
        /// </summary>
        /// <param name="product">Database product object.</param>
        /// <returns>Returnt dto object.</returns>
        public static ProductDto MapProductToProductDto(Product product) => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImgUrl = product.ImgUrl,
            Price = product.Price
        };

        /// <summary>
        /// Map collection of database objects product to collecton of productDto.
        /// </summary>
        /// <param name="products">Collection of database product objects.</param>
        /// <returns>Returns collection of prductDto objects.</returns>
        public static IEnumerable<ProductDto> MapProductsToProductDtos(IEnumerable<Product> products) => products.Select(MapProductToProductDto);
    }
}
