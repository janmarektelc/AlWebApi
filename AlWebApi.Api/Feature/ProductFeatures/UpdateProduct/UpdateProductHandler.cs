using AlTest.Models;
using MediatR;

namespace AlWebApi.Api.Feature.ProductFeatures.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
    {
        private readonly ILogger<UpdateProductHandler> logger;

        public UpdateProductHandler(ILogger<UpdateProductHandler> logger)
        {
            this.logger = logger;
        }

        public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API update product with id {request.ProductId} called.");
            var product = new ProductDto { Id = request.ProductId, Price = 10, Name = "product1", ImgUrl = "url", Description = request.Description };
            logger.LogInformation($"Product with id {product.Id} - updated description to {product.Description}");

            return await Task.FromResult(product);
        }
    }
}
