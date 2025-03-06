using AlTest.Models;
using MediatR;

namespace AlWebApi.Api.Feature.ProductFeatures.GetProducts
{
    public class GetProductsCommand : IRequest<IEnumerable<ProductDto>?>
    {
    }
}
