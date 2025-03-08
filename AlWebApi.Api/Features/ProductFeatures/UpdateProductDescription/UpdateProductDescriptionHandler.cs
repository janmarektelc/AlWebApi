using AlWebApi.Api.Helpers;
using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription
{
    public class UpdateProductDescriptionHandler : IRequestHandler<UpdateProductDescriptionCommand, ProductDto?>
    {
        private readonly ILogger<UpdateProductDescriptionHandler> logger;
        private readonly IMainDbRepository mainRepository;

        public UpdateProductDescriptionHandler(ILogger<UpdateProductDescriptionHandler> logger, IMainDbRepository mainRepository)
        {
            this.logger = logger;
            this.mainRepository = mainRepository;
        }

        public async Task<ProductDto?> Handle(UpdateProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API update product with id {request.ProductId} called.");
            var product = await mainRepository.UpdateProductDescription(request.ProductId, request.Description, cancellationToken); 
            if (product == null)
            {
                logger.LogInformation($"Product with id {request.ProductId} not found.");
                return null;
            }
            logger.LogInformation($"Product with id {product.Id} - updated description to {product.Description}");

            return Mapper.MapProductToProductDto(product);
        }
    }
}
