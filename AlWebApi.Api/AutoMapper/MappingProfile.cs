using AlWebApi.Api.Entities;
using AlWebApi.Api.Models;
using AutoMapper;

namespace AlWebApi.Api.AutoMapper
{
    /// <summary>
    /// Mapping profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
