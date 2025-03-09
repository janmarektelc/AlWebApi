using AlWebApi.Api.Features.ProductFeatures.GetProducts;
using AlWebApi.Api.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Features
{
    [TestClass]
    [TestCategory("Features")]
    public class GetProductsHandlerTests
    {
        private readonly GetProductsHandler handler;

        public GetProductsHandlerTests()
        {
            handler = new GetProductsHandler(A.Fake<ILogger<GetProductsHandler>>(), new ProductsRepositoryMock());
        }

        [TestMethod]
        public async Task GetProductsHandlerTestSuccess()
        {
            var result = await handler.Handle(new GetProductsCommand(), default);
            result.Should().NotBeNull();
            result.Should().HaveCountGreaterThan(50);
        }
    }
}
