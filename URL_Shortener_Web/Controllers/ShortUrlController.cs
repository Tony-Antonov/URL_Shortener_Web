using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_Web.Requestes;

namespace URL_Shortener_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        IShortUrlService shortUrlService;
        public ShortUrlController(IShortUrlService shortUrlService)
        {
            this.shortUrlService= shortUrlService;
        }

        [HttpGet]
        public async Task<ActionResult> GetShortUrl(int id) 
        {
            var a = await shortUrlService.GetShortUrl(id);
            return Ok(a);
        }

        [HttpGet]
        public async Task<ActionResult> GetShortUrl()
        {
            var a = await shortUrlService.Get();
            return Ok(a);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateShortUrlRequest request)
        {
            var a = await shortUrlService.Create(ToDomainModel(request));
            return Ok(a);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await shortUrlService.DeleteShortUrl(id);
            return Ok();
        }

        private ShortUrl ToDomainModel(CreateShortUrlRequest request)
        {
            return new ShortUrl();
        }
    }
}
