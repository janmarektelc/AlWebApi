using AlWebApi.Api.Controllers.V1;
using AlWebApi.Api.Features.ProductFeatures.GetProduct;
using AlWebApi.Api.Features.ProductFeatures.GetProducts;
using AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription;
using AlWebApi.Api.Models;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Controllers.V1
{
    [TestClass]
    [TestCategory("Controllers")]
    public class ProductControllerTests
    {
        private readonly IMediator mediator;
        private readonly ProductController controller;

        public ProductControllerTests()
        {
            mediator = A.Fake<IMediator>();
            controller = new ProductController(A.Fake<ILogger<ProductController>>(), mediator);
        }

        [TestMethod]
        public async Task GetProductsHandlerCallTest()
        {
            A.CallTo(() => mediator.Send(A<GetProductsCommand>._, default)).Returns([new ProductDto()]);

            var actionResult = await controller.GetProducts(default);

            A.CallTo(() => mediator.Send(A<GetProductsCommand>._, default)).MustHaveHappenedOnceExactly();
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as ObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [TestMethod]
        public async Task GetProductsNotFoundTest()
        {
            A.CallTo(() => mediator.Send(A<GetProductsCommand>._, default)).Returns<IEnumerable<ProductDto>?>(null);

            var actionResult = await controller.GetProducts(default);
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as NotFoundResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [TestMethod]
        public async Task GetProductsNotFoundTestEmptyCollection()
        {
            A.CallTo(() => mediator.Send(A<GetProductsCommand>._, default)).Returns([]);

            var actionResult = await controller.GetProducts(default);
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as NotFoundResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [TestMethod]
        public async Task GetProductHandlerCallTest()
        {
            var actionResult = await controller.GetProduct(1, default);

            A.CallTo(() => mediator.Send(A<GetProductCommand>._, default)).MustHaveHappenedOnceExactly();
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as ObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [TestMethod]
        public async Task GetProductNotFoundTest()
        {
            A.CallTo(() => mediator.Send(A<GetProductCommand>._, default)).Returns<ProductDto?>(null);

            var actionResult = await controller.GetProduct(1, default);
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as NotFoundResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [TestMethod]
        public async Task UpdateProductHandlerCallTest()
        {
            var actionResult = await controller.UpdateProduct(new UpdateProductDescriptionDto { Id = 1, Description = "new testing description" }, default);

            A.CallTo(() => mediator.Send(A<UpdateProductDescriptionCommand>._, default)).MustHaveHappenedOnceExactly();
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as ObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [TestMethod]
        public async Task UpdateProductNotFoundTest()
        {
            A.CallTo(() => mediator.Send(A<UpdateProductDescriptionCommand>._, default)).Returns<ProductDto?>(null);

            var actionResult = await controller.UpdateProduct(new UpdateProductDescriptionDto { Id = 1, Description = "new testing description" }, default);
            actionResult.Should().NotBeNull();

            var result = actionResult.Result as NotFoundResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
