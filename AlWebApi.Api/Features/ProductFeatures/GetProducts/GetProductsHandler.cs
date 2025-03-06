using AlWebApi.Api.Entities;
using AlWebApi.Api.Models;
using AlWebApi.Api.Repositories;
using MediatR;

namespace AlWebApi.Api.Features.ProductFeatures.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<ProductDto>?>
    {
        private readonly ILogger<GetProductsHandler> logger;
        private readonly MainDbRepository mainRepository;

        public GetProductsHandler(ILogger<GetProductsHandler> logger, MainDbRepository mainRepository)
        {
            this.logger = logger;
            this.mainRepository = mainRepository;
        }

        public async Task<IEnumerable<ProductDto>?> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Entered handler for get all products.");
            var products = await mainRepository.GetProducts(cancellationToken);
            logger.LogInformation($"Loaded {products.Count()} products from database.");

            return products.Select(p => new ProductDto {Id = p.Id, Name = p.Name, Description = p.Description, ImgUrl = p.ImgUrl, Price = p.Price});
        }
    }
}
