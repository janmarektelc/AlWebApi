using AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription;
using AlWebApi.Api.Interfaces;
using AlWebApi.Api.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Features
{
    [TestClass]
    [TestCategory("Features")]
    public class UpdateProductDescriptionHandlerTests
    {
        private readonly UpdateProductDescriptionHandler handler;
        private readonly IProductsRepository mainRepository;

        public UpdateProductDescriptionHandlerTests()
        {
            mainRepository = new ProductsRepositoryMock();
            handler = new UpdateProductDescriptionHandler(A.Fake<ILogger<UpdateProductDescriptionHandler>>(), mainRepository);
        }

        [TestMethod]
        public async Task UpdateProductHandlerTestSuccess()
        {
            var productToChangeId = 3;
            var newProductDescription = "New description";
            var result = await handler.Handle(new UpdateProductDescriptionCommand(productToChangeId, newProductDescription), default);
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
            var result = await handler.Handle(new UpdateProductDescriptionCommand(productToChangeId, null), default);
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
            var result = await handler.Handle(new UpdateProductDescriptionCommand(int.MaxValue, "New description"), default);
            result.Should().BeNull();
        }
    }
}
