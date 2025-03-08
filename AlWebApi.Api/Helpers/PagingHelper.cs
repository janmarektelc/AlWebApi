namespace AlWebApi.Api.Helpers
{
    /// <summary>
    /// Helper class for paging.
    /// </summary>
    public static class PagingHelper
    {
        /// <summary>
        /// Validates page number and page size for products.
        /// </summary>
        /// <param name="pageNumber">Page number to validate.</param>
        /// <param name="pageSize">Page size to validate.</param>
        public static void ValidateProductPageNumberAndPageSize(uint pageNumber, uint pageSize)
        {
            if (pageNumber <= 0)
            {
                throw new Exception("Page number must be greater than 0.");
            }
            if (pageSize < Constants.ProductMinPageSize)
            {
                throw new Exception($"Page number size must be greater than {Constants.ProductMinPageSize}.");
            }
            if (pageNumber > Constants.ProductMaxPageNumber)
            {
                throw new Exception($"Page number must be less or equal than {Constants.ProductMaxPageNumber}.");
            }
            if (pageSize > Constants.ProductMaxPageSize)
            {
                throw new Exception($"Page size must be less or equal than {Constants.ProductMaxPageSize}.");
            }
        }
    }
}
