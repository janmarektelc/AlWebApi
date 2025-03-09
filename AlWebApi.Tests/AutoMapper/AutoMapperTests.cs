using AlWebApi.Tests.Helpers;

namespace AlWebApi.Tests.AutoMapper
{
    [TestClass]
    [TestCategory("AutoMapper")]
    public class AutoMapperTests
    {
        [TestMethod]
        public void AutoMapperTest()
        {
            var mapper = AutoMapperHelper.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
