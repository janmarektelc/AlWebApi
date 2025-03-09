using AlWebApi.Api.AutoMapper;
using AutoMapper;

namespace AlWebApi.Tests.Helpers
{
    internal static class AutoMapperHelper
    {
        public static IMapper CreateMapper() => 
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
    }
}
