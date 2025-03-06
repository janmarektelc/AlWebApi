using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Feature.ProductFeatures.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ProductDto?>
    {
        private readonly ILogger<GetProductHandler> logger;

        public GetProductHandler(ILogger<GetProductHandler> logger)
        {
            this.logger = logger;
        }

        public async Task<ProductDto?> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Entered handler for get product with id {request.ProductId}.");
            var product = new ProductDto { Id = request.ProductId, Price = 10, Name = "product1", ImgUrl = "url" };

            return await Task.FromResult(product);
        }
    }
}
