using AlTest.Models;
using MediatR;

namespace AlWebApi.Api.Feature.ProductFeatures.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
        public string? Description { get; set; }

        public UpdateProductCommand(Guid productId, string? description)
        {
            ArgumentNullException.ThrowIfNull(productId);
            ProductId = productId;
            Description = description;
        }
    }
}
