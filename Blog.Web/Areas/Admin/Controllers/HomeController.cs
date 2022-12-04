using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleServices _articleServices;

        public HomeController(IArticleServices articleServices)
        {
            this._articleServices = articleServices;
        }




        public async Task<IActionResult> Index()
        {
            var article = await _articleServices.GetAllArticlesAsycn();

            return View(article);
        }
    }
}
