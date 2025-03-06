using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto?>
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }

        public UpdateProductCommand(int productId, string? description)
        {
            ArgumentNullException.ThrowIfNull(productId);
            ProductId = productId;
            Description = description;
        }
    }
}
