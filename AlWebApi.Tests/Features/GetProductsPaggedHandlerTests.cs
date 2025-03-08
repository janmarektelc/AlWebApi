using AlWebApi.Api;
using AlWebApi.Api.Features.ProductFeatures.GetProductsPagged;
using AlWebApi.Api.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AlWebApi.Tests.Features
{
    [TestClass]
    [TestCategory("Features")]
    public class GetProductsPaggedHandlerTests
    {
        private readonly GetProductsPaggedHandler handler;
        public GetProductsPaggedHandlerTests()
        {
            handler = new GetProductsPaggedHandler(A.Fake<ILogger<GetProductsPaggedHandler>>(), new MainDbRepositoryMock());
        }

        [TestMethod]
        public async Task GetProductsPaggedHandlerTestSuccess()
        {
            var result = await handler.Handle(new GetProductsPaggedCommand(1, 10), default);
            result.Should().NotBeNull();
            result.Should().HaveCount(10);

            result = await handler.Handle(new GetProductsPaggedCommand(2, 6), default);
            result.Should().NotBeNull();
            result.Should().HaveCount(6);
            result.First().Id.Should().Be(6);

            result = await handler.Handle(new GetProductsPaggedCommand(3, 6), default);
            result.Should().NotBeNull();
            result.Should().HaveCount(6);
            result.First().Id.Should().Be(12);

            result = await handler.Handle(new GetProductsPaggedCommand(2, 100), default);
            result.Should().NotBeNull();
            result.Should().HaveCount(50);

            result = await handler.Handle(new GetProductsPaggedCommand(Constants.ProductMaxPageNumber, Constants.ProductMaxPageSize), default);
            result.Should().NotBeNull();

        }

        [TestMethod]
        public async Task GetProductsPaggedHandlerTestNoDataFound()
        {
            var result = await handler.Handle(new GetProductsPaggedCommand(500, 10), default);
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void GetProductsPaggedHandlerTestInvalidPage()
        {
            Assert.ThrowsException<AggregateException>(() => handler.Handle(new GetProductsPaggedCommand(0, 10), default).Wait(), "Page number must be greater than 0.");
            Assert.ThrowsException<AggregateException>(() => handler.Handle(new GetProductsPaggedCommand(1, 0), default).Wait(), $"Page number size must be greater than {Constants.ProductMinPageSize}.");
            Assert.ThrowsException<AggregateException>(() => handler.Handle(new GetProductsPaggedCommand(Constants.ProductMaxPageNumber + 1, 10), default).Wait(), $"Page number must be less or equal than {Constants.ProductMaxPageNumber}.");
            Assert.ThrowsException<AggregateException>(() => handler.Handle(new GetProductsPaggedCommand(1, Constants.ProductMaxPageSize + 1), default).Wait(), $"Page size must be less or equal than {Constants.ProductMaxPageSize}.");

        }

        [TestMethod]
        public void TestMaximumSkippedOrders()
        {
            var maxSkipedOrders = (int)((Constants.ProductMaxPageNumber - 1) * Constants.ProductMaxPageSize);
            maxSkipedOrders.Should().BeGreaterThan(0);
            maxSkipedOrders.Should().BeLessThan(int.MaxValue);

        }
    }
}
