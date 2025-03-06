using AlWebApi.Api.Models;
using MediatR;

namespace AlWebApi.Api.Feature.ProductFeatures.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<ProductDto>?>
    {
        private readonly ILogger<GetProductsHandler> logger;

        public GetProductsHandler(ILogger<GetProductsHandler> logger)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<ProductDto>?> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Entered handler for get all products.");
            var products = new[] 
            { 
                new ProductDto { Id = Guid.NewGuid(), Price = 10, Name = "product1", ImgUrl = "url" },
                new ProductDto { Id = Guid.NewGuid(), Price = 123, Name = "product2", ImgUrl = "url" },
                new ProductDto { Id = Guid.NewGuid(), Price = 358, Name = "product3", ImgUrl = "url" },
            };

            return await Task.FromResult(products);
        }
    }
}
