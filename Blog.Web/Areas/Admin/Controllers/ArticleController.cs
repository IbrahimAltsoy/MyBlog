using Blog.Entity.DTOS.Articles;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        private readonly ICategoryService _categoryService;

        public ArticleController(IArticleServices articleServices, ICategoryService categoryService)
        {
            this._articleServices = articleServices;
            this._categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleServices.GetAllArticlesWithCategoryNonDeletedAsycn();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTO { categories =categories});
        }
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
        {
            await _articleServices.CreateArticleAsync(articleAddDTO);
            RedirectToAction("Index", "Admin", new { Areas = "Admin" });
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDTO { categories = categories });
        }
    }
}
