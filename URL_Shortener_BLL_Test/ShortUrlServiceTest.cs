using Moq;
using URL_Shortener_BLL.Services;
using URL_Shortener_DAL.Interfaces;


namespace URL_Shortener_BLL_Test
{
    public class ShortUrlServiceTest
    {
        private readonly ShortUrlService shortUrlService;
        private readonly Mock<IUnitOfWork> EFWorkUnitMock = new Mock<IUnitOfWork>();
        public ShortUrlServiceTest()
        {
            shortUrlService = new ShortUrlService(EFWorkUnitMock.Object);
        }


        [Theory]
        [InlineData("")]
        [InlineData("tony")]
        public async void FailedToCreateUrl(string url)
        {
            var result = await shortUrlService.Create(url, 1);

            Assert.False(result.Completed);
        }
    }
}