using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleServices _articleServices;

        public HomeController(ILogger<HomeController> logger, IArticleServices articleServices)
        {
            _logger = logger;
            this._articleServices = articleServices;
        }

        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleServices.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
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
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _articleServices.GetArticleWithCategoryNonDeletedAsycn(id);
            return View(model);
        }
    }
}