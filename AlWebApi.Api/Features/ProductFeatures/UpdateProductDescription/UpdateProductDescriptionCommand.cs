using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription
{
    public class UpdateProductDescriptionCommand : IRequest<ProductDto?>
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }

        public UpdateProductDescriptionCommand(int productId, string? description)
        {
            ProductId = productId;
            Description = description;
        }
    }
}
