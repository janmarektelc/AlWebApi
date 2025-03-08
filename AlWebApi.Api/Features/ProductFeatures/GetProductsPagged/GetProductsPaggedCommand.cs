using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProductsPagged
{
    public class GetProductsPaggedCommand : IRequest<IEnumerable<ProductDto>?>
    {
        public uint PageNumber { get; set; }
        public uint PageSize { get; set; }

        public GetProductsPaggedCommand(uint pageNumber, uint pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
