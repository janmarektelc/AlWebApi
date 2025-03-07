using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Features.ProductFeatures.GetProduct;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Features
{
    [TestClass]
    [TestCategory("Features")]
    public class GetProductHandlerTests
    {
        private readonly GetProductHandler handler;

        public GetProductHandlerTests()
        {
            handler = new GetProductHandler(A.Fake<ILogger<GetProductHandler>>(), new MainDbRepositoryMock());
        }

        [TestMethod]
        public async Task GetProductHandlerTestSuccess()
        {
            var result = await handler.Handle(new GetProductCommand(1), default);
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
        }

        [TestMethod]
        public async Task GetProductHandlerTestNotFound()
        {
            var result = await handler.Handle(new GetProductCommand(int.MaxValue), default);
            result.Should().BeNull();
        }
    }
}
