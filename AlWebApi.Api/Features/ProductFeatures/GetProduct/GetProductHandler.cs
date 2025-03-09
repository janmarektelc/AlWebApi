using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ProductDto?>
    {
        private readonly ILogger<GetProductHandler> logger;
        private readonly IProductsRepository mainRepository;

        public GetProductHandler(ILogger<GetProductHandler> logger, IProductsRepository mainRepository)
        {
            this.logger = logger;
            this.mainRepository = mainRepository;
        }

        public async Task<ProductDto?> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Entered handler for get product with id {request.ProductId}.");
            var product = await mainRepository.GetProductById(request.ProductId, cancellationToken);
            if (product == null)
            {
                logger.LogInformation($"Product with id {request.ProductId} not found.");
            }
            else
            {
                logger.LogInformation($"Product with id {request.ProductId} loaded.");
            }

            return product != null ? Mapper.MapProductToProductDto(product) : null;
        }
    }
}
