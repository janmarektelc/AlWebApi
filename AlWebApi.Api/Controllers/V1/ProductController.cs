using AlTest.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AlTest.Controllers.V1
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

        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets all produts.
        /// </summary>
        /// <returns>Returns all products.</returns>
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            logger.LogInformation("Get all product called.");
            var products = new []{ new ProductDto { Id = Guid.NewGuid(), Price = 10, Name = "product1", ImgUrl = "url" } };

            return Ok(products);
        }

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <returns>Returns product by id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDto> GetProducts(Guid id)
        {
            logger.LogInformation($"Get product for id {id} called.");
            var product = new ProductDto { Id =id, Price = 10, Name = "product1", ImgUrl = "url" };

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDto> UpdateProduct(Guid id, [FromBody] string description)
        {
            logger.LogInformation("Update product called.");
            var product = new ProductDto { Id = id, Price = 10, Name = "product1", ImgUrl = "url", Description = description };

            return Ok(product);
        }
    }
}
