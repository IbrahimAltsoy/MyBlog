using AutoMapper;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Services.Abstractions;
using Blog.Web.ToastrMessaje;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleServices _articleServices;
        private readonly ICategoryService _categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toastNotification;


        public ArticleController(IArticleServices articleServices, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)// Buraya fluentvalidator ekledik. Field ını da ekledik akbinde create ad metodlarına girecez. 
        {
            this._articleServices = articleServices;
            this._categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
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
                toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddSuccesfull(articleAddDTO.Title), new ToastrOptions
                {
                    Title = "Başarılı"
                });
                return RedirectToAction("Index", "Article", new { Areas = "Admin" });


            }
            else
            {
                // AddToModelState bunu bizim eklediğimiz extensions ten çağırıyoruz. Dikkat et buraya 
                toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddUnSuccessful(articleAddDTO.Title), new ToastrOptions
                {
                    Title = "Başarısız"
                }); 
                result.AddToModelState(this.ModelState);
                

            }
            // Validation işlemi burada bitirmiş oluyoruz artık işleme girmiş oluyor. 
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
            var map = mapper.Map<Article>(articleUpdateDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _articleServices.UpdateArticleAsync(articleUpdateDTO);
                toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateSuccesfull(articleUpdateDTO.Title), new ToastrOptions
                {
                    Title = "Başarılı"
                });
                return RedirectToAction("Index", "Article", new { Areas = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateUnSuccessful(articleUpdateDTO.Title), new ToastrOptions
                {
                    Title = "Başarısız"
                });
            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDTO.categories = categories;
            return View(articleUpdateDTO);





        }
        public async Task<IActionResult> Delete(Guid articleId)
        {
            var deleteArticle = await _articleServices.GetArticleWithCategoryNonDeletedAsycn(articleId);

            await _articleServices.SafeArticleDeleteAsync(articleId);
            toastNotification.AddWarningToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleDeleteSuccessful(deleteArticle.Title), new ToastrOptions
            {
                Title = "Başarılı"
            });

            return RedirectToAction("Index", "Article", new { Areas = "Admin" });
        }
    }
}
