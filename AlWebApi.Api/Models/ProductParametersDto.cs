using System.ComponentModel.DataAnnotations;

namespace AlWebApi.Api.Models
{
    /// <summary>
    /// Data transfer object for product parameters to enable paging. Could be extended with sorting and filtering.
    /// </summary>
    public class ProductParametersDto
    {
        /// <summary>
        /// Page number from 1.
        /// </summary>
        [Range(1, Constants.ProductMaxPageNumber)]
        [Required]
        public uint PageNumber { get; set; } = 1;

        /// <summary>
        /// Page size.
        /// </summary>
        [Range(Constants.ProductMinPageSize, Constants.ProductMaxPageSize)]
        public uint PageSize { get; set; } = Constants.ProductDefaultPageSize;
    }
}
