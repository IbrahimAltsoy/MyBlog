using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;

        public ArticleController(IArticleServices articleServices)
        {
            this._articleServices = articleServices;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleServices.GetAllArticlesWithCategoryNonDeletedAsycn();
            return View(articles);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
