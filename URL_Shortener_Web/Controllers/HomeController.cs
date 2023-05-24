using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_Web.Models;

namespace URL_Shortener_Web.Controllers
{
    public class HomeController : Controller
    {
        IShortUrlService shortUrlService;

        public HomeController(ILogger<HomeController> logger, IShortUrlService shortUrlService)
        {
            this.shortUrlService = shortUrlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{anyLetters}")]
        public async Task<IActionResult> RedirectTo(string anyLetters)
        {
            var shortUrl = await shortUrlService.GetShortUrlByCode(anyLetters);
            
            return shortUrl != null? Redirect($"{shortUrl.Url}") : View("PageNotFound");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}