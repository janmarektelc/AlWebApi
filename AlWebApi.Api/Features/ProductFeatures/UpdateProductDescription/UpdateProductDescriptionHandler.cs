using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using AutoMapper;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription
{
    public class UpdateProductDescriptionHandler : IRequestHandler<UpdateProductDescriptionCommand, ProductDto?>
    {
        private readonly ILogger<UpdateProductDescriptionHandler> logger;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public UpdateProductDescriptionHandler(ILogger<UpdateProductDescriptionHandler> logger, IProductsRepository productsRepository, IMapper mapper)
        {
            this.logger = logger;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto?> Handle(UpdateProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API update product with id {request.ProductId} called.");
            var product = await productsRepository.UpdateProductDescription(request.ProductId, request.Description, cancellationToken); 
            if (product == null)
            {
                logger.LogInformation($"Product with id {request.ProductId} not found.");
                return null;
            }
            logger.LogInformation($"Product with id {product.Id} - updated description to {product.Description}");

            return mapper.Map<ProductDto>(product);
        }
    }
}
