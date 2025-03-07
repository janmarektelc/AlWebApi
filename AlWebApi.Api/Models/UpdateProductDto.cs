using System.ComponentModel.DataAnnotations;

namespace AlWebApi.Api.Models
{
    /// <summary>
    /// Data transfer object for updating a product.
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// Product Id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Optional product description.
        /// </summary>
        public string? Description { get; set; }
    }
}
