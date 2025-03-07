using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlWebApi.Api.Entities
{
    /// <summary>
    /// Entity for product.
    /// </summary>
    public class Product : EntityBase
    {

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Url to the product image.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string ImgUrl { get; set; } = string.Empty;

        /// <summary>
        /// Price of the product.
        /// </summary>
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Optional product description.
        /// </summary>
        [MaxLength(1024)]
        public string? Description { get; set; }
    }
}
