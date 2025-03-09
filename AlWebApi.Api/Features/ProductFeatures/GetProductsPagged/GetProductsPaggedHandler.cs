using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using AutoMapper;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProductsPagged
{
    public class GetProductsPaggedHandler : IRequestHandler<GetProductsPaggedCommand, IEnumerable<ProductDto>?>
    {
        private readonly ILogger<GetProductsPaggedHandler> logger;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public GetProductsPaggedHandler(ILogger<GetProductsPaggedHandler> logger, IProductsRepository productsRepository, IMapper mapper)
        {
            this.logger = logger;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>?> Handle(GetProductsPaggedCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Entered handler for get products pagged.");
            var products = await productsRepository.GetProducts(request.PageNumber, request.PageSize, cancellationToken);
            if (products == null || products.Count() == 0)
            {
                logger.LogInformation($"There is no product at the page.");
            }
            else
            {
                logger.LogInformation($"Loaded {products.Count()} products from database.");
            }

            return products != null ? mapper.Map<IEnumerable<ProductDto>>(products) : null;
        }
    }
}
