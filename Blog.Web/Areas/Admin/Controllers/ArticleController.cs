using AutoMapper;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        private readonly ICategoryService _categoryService;
        private readonly IMapper mapper;

        public ArticleController(IArticleServices articleServices, ICategoryService categoryService, IMapper mapper)
        {
            this._articleServices = articleServices;
            this._categoryService = categoryService;
            this.mapper = mapper;
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
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleServices.GetArticleWithCategoryNonDeletedAsycn(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            var articleUpdateDto = mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDto.categories= categories;
            return View(articleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)
        {
            await _articleServices.UpdateArticleAsync(articleUpdateDTO);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            articleUpdateDTO.categories = categories;
            return View(articleUpdateDTO);


        }
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await _articleServices.SafeArticleDeleteAsync(articleId);
            return RedirectToAction("Index", "Article", new { Areas = "Admin" });
        }
    }
}
