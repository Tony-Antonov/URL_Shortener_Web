using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Services;
using URL_Shortener_DAL.Entities;
using URL_Shortener_Web.Models;

namespace URL_Shortener_Web.Controllers
{
    public class ShortenerUrlController : Controller
    {
        IShortUrlService shortUrlService;
        UserManager<UserEntity> userManager;
        public ShortenerUrlController(IShortUrlService shortUrlService, UserManager<UserEntity> userManager)
        {
            this.userManager = userManager;
            this.shortUrlService = shortUrlService;
        }

        // GET: ShortenerUrlController
        public async Task<ActionResult> UrlList()
        {
            var Urls = await shortUrlService.Get();
            List<UrlListViewModel> newlist = new List<UrlListViewModel>();
            foreach(var item in Urls)
            {
                newlist.Add(new UrlListViewModel()
                {
                    Url = item.Url,
                    ShortUrl = item.ShortedUrl,
                    Id = item.Id,
                    UserName = item.CreatedBy.Username
                });
            }
            return View(newlist);
        }

        // GET: ShortenerUrlController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var shortUrl = await shortUrlService.GetShortUrlById(id);
            var shortUrlInfo = new UrlInfoViewModel()
            {
                Url = shortUrl.Url,
                ShortedUrl = shortUrl.ShortedUrl,
                CreatedBy = shortUrl.CreatedBy.Username,
                CreatedDate = shortUrl.CreatedDate,
            };
            return View("Details", shortUrlInfo);
        }

        // GET: ShortenerUrlController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShortenerUrlController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Url)
        {   
            
            var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;
            var result = await shortUrlService.Create(Url,userId);
            if (result.Completed)
            {
                return RedirectToAction("UrlList", "ShortenerUrl");
            }
            ModelState.AddModelError("", result.Message);
            return View("Create",new UrlCreationModel() { Url = Url });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await shortUrlService.DeleteShortUrl(id);

            return RedirectToAction("UrlList", "ShortenerUrl");
        }
    }
}
