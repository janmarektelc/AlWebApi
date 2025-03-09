using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using AutoMapper;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ProductDto?>
    {
        private readonly ILogger<GetProductHandler> logger;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public GetProductHandler(ILogger<GetProductHandler> logger, IProductsRepository productsRepository, IMapper mapper)
        {
            this.logger = logger;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Entered handler for get product with id {request.ProductId}.");
            var product = await productsRepository.GetProductById(request.ProductId, cancellationToken);
            if (product == null)
            {
                logger.LogInformation($"Product with id {request.ProductId} not found.");
            }
            else
            {
                logger.LogInformation($"Product with id {request.ProductId} loaded.");
            }

            return product != null ? mapper.Map<ProductDto>(product) : null;
        }
    }
}
