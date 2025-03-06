using AlWebApi.Api.Feature.ProductFeatures.GetProduct;
using AlWebApi.Api.Feature.ProductFeatures.GetProducts;
using AlWebApi.Api.Feature.ProductFeatures.UpdateProduct;
using AlWebApi.Api.Models;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlWebApi.Api.Controllers.V1
{
    /// <summary>
    /// Product controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMediator mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets all produts.
        /// </summary>
        /// <returns>Returns all products.</returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await mediator.Send(new GetProductsCommand(), cancellationToken);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <returns>Returns product by id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API get product for id {id} called.");
            var product = await mediator.Send(new GetProductCommand(id), cancellationToken);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Update product description.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="description">New description.</param>
        /// <returns>Returns updated product.</returns>
        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> UpdateProduct(Guid id, [FromBody] string description, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API update product with id {id} called.");
            var product = await mediator.Send(new UpdateProductCommand(id, description), cancellationToken);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
