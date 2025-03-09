using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using AutoMapper;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<ProductDto>?>
    {
        private readonly ILogger<GetProductsHandler> logger;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public GetProductsHandler(ILogger<GetProductsHandler> logger, IProductsRepository productsRepository, IMapper mapper)
        {
            this.logger = logger;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>?> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Entered handler for get all products.");
            var products = await productsRepository.GetProducts(cancellationToken);
            if (products == null || products.Count() == 0)
            {
                logger.LogInformation($"There is no product in database.");
            }
            else
            {
                logger.LogInformation($"Loaded {products.Count()} products from database.");
            }

            return products != null ? mapper.Map<IEnumerable<ProductDto>>(products) : null;
        }
    }
}
