using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<ProductDto>?>
    {
        private readonly ILogger<GetProductsHandler> logger;
        private readonly IMainDbRepository mainRepository;

        public GetProductsHandler(ILogger<GetProductsHandler> logger, IMainDbRepository mainRepository)
        {
            this.logger = logger;
            this.mainRepository = mainRepository;
        }

        public async Task<IEnumerable<ProductDto>?> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Entered handler for get all products.");
            var products = await mainRepository.GetProducts(cancellationToken);
            if (products == null || products.Count() == 0)
            {
                logger.LogInformation($"There is no product in database.");
            }
            else
            {
                logger.LogInformation($"Loaded {products.Count()} products from database.");
            }

            return products != null ? Mapper.MapProductsToProductDtos(products) : null;
        }
    }
}
