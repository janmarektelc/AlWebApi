using System.ComponentModel.DataAnnotations;

namespace AlTest.Models
{
    /// <summary>
    /// Product dto.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product Id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url to the product image.
        /// </summary>
        [Required]
        public string ImgUrl { get; set; } = string.Empty;

        /// <summary>
        /// Price of the product.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Optional product description.
        /// </summary>
        public string? Description{ get; set; }
    }
}
