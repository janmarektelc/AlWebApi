using AlWebApi.Api.Features.ProductFeatures.GetProduct;
using AlWebApi.Api.Features.ProductFeatures.GetProductsPagged;
using AlWebApi.Api.Features.ProductFeatures.UpdateProductDescription;
using AlWebApi.Api.Models;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlWebApi.Api.Controllers.V2
{
    /// <summary>
    /// Product controller.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="mediator">Mediator.</param>
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] ProductParametersDto parameters, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API v2.0 get all products pagged called.");
            var products = await mediator.Send(new GetProductsPaggedCommand(parameters.PageNumber, parameters.PageSize), cancellationToken);

            if (products == null || !products.Any())
            {
                logger.LogInformation("No products found.");

                return NotFound();
            }
            logger.LogInformation($"Found {products.Count()} products.");

            return Ok(products);
        }

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <returns>Returns product by id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API v2.0 get product for id {id} called.");
            var product = await mediator.Send(new GetProductCommand(id), cancellationToken);

            if (product == null)
            {
                logger.LogInformation($"Product with id {id} not found.");

                return NotFound();
            }
            logger.LogInformation($"Found {product.Id} products.");

            return Ok(product);
        }

        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="updateProductDto">Data object with changes.</param>
        /// <returns>Returns updated product.</returns>        
        [HttpPatch("UpdateDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromBody] UpdateProductDescriptionDto updateProductDto, CancellationToken cancellationToken)
        {
            logger.LogInformation($"API v2.0 update product with id {updateProductDto.Id} called.");
            var product = await mediator.Send(new UpdateProductDescriptionCommand(updateProductDto.Id, updateProductDto.Description), cancellationToken);

            if (product == null)
            {
                logger.LogInformation($"Product with id {updateProductDto.Id} not found.");

                return NotFound();
            }
            logger.LogInformation($"Product with id {product.Id} has updated description to {product.Description}.");

            return Ok(product);
        }
    }
}
