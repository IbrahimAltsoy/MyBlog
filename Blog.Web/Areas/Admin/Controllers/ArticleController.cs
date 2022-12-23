using AutoMapper;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        private readonly ICategoryService _categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;

        public ArticleController(IArticleServices articleServices, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)// Buraya fluentvalidator ekledik. Field ını da ekledik akbinde create ad metodlarına girecez. 
        {
            this._articleServices = articleServices;
            this._categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
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
            //  var result = await validator.ValidateAsync(articleAddDTO); Normalde böyle kullanacaktık fakat biz burada Dto gönderemeyiz çünkü biz fluentvalidationu Article entity göre kurduk. o yüzden burada mapping işlemi yapıp öyle işleme alacağız bunu da aşağıdaki kodlarlar sağlamış olacaz. 
            var map = mapper.Map<Article>(articleAddDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _articleServices.CreateArticleAsync(articleAddDTO);
               return RedirectToAction("Index", "Admin", new { Areas = "Admin" });


            }
            else
            {
                // AddToModelState bunu bizim eklediğimiz extensions ten çağırıyoruz. Dikkat et buraya 
                result.AddToModelState(this.ModelState);
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleAddDTO { categories = categories });
            }
            // Validation işlemi burada bitirmiş oluyoruz artık işleme girmiş oluyor. 

        
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
