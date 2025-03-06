using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProducts
{
    public class GetProductsCommand : IRequest<IEnumerable<ProductDto>?>
    {
    }
}
