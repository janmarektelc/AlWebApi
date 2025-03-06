using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProduct
{
    public class GetProductCommand : IRequest<ProductDto?>
    {
        public Guid ProductId { get; set; }

        public GetProductCommand(Guid productId)
        {
            ArgumentNullException.ThrowIfNull(productId);
            ProductId = productId;
        }
    }
}
