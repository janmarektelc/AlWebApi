using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProduct
{
    public class GetProductCommand : IRequest<ProductDto?>
    {
        public int ProductId { get; set; }

        public GetProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
