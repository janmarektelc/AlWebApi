using AlWebApi.Api.DbContexts;
using AlWebApi.Api.Features.ProductFeatures.UpdateProduct;
using AlWebApi.Api.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Features
{
    [TestClass]
    [TestCategory("Features")]
    public class UpdateProductHandlerTests
    {
        private readonly UpdateProductHandler handler;
        private readonly IMainDbRepository mainRepository;

        public UpdateProductHandlerTests()
        {
            mainRepository = new MainDbRepositoryMock();
            handler = new UpdateProductHandler(A.Fake<ILogger<UpdateProductHandler>>(), mainRepository);
        }

        [TestMethod]
        public async Task UpdateProductHandlerTestSuccess()
        {
            var productToChangeId = 3;
            var newProductDescription = "New description";
            var result = await handler.Handle(new UpdateProductCommand(productToChangeId, newProductDescription), default);
            result.Should().NotBeNull();
            result.Id.Should().Be(3);
            result.Description.Should().Be(newProductDescription);

            var product = await mainRepository.GetProductById(productToChangeId, default);
            product.Should().NotBeNull();
            product!.Description.Should().Be(newProductDescription);
        }

        [TestMethod]
        public async Task UpdateProductHandlerTestNoDescription()
        {
            var productToChangeId = 3;
            var result = await handler.Handle(new UpdateProductCommand(productToChangeId, null), default);
            result.Should().NotBeNull();
            result.Id.Should().Be(3);
            result.Description.Should().Be(null);

            var product = await mainRepository.GetProductById(productToChangeId, default);
            product.Should().NotBeNull();
            product!.Description.Should().Be(null);
        }

        [TestMethod]
        public async Task UpdateProductHandlerTestNotFound()
        {
            var result = await handler.Handle(new UpdateProductCommand(int.MaxValue, "New description"), default);
            result.Should().BeNull();
        }
    }
}
