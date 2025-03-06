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
            logger.LogInformation("Get all product called.");
            var products = new ProductDto { Id =id, Price = 10, Name = "product1", ImgUrl = "url" };

            return Ok(products);
        }
    }
}
