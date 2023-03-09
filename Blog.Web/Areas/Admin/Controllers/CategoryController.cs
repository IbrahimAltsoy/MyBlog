using AutoMapper;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CategoryController : Controller
    {


        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toastNotification;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification toastNotification)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
         
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> UnDeleted()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
           
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO)
        {
            //  var result = await validator.ValidateAsync(articleAddDTO); Normalde böyle kullanacaktık fakat biz burada Dto gönderemeyiz çünkü biz fluentvalidationu Article entity göre kurduk. o yüzden burada mapping işlemi yapıp öyle işleme alacağız bunu da aşağıdaki kodlarlar sağlamış olacaz. 
            var map = mapper.Map<Category>(categoryAddDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {

                await categoryService.CreateCategoryAsync(categoryAddDTO);
                toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddSuccesfull(categoryAddDTO.Name), new ToastrOptions
                {
                    Title = "Başarılı"
                });
                return RedirectToAction("Index", "Category", new { Areas = "Admin" });


            }
            else
            {
                result.AddToModelState(this.ModelState);
                toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddUnSuccessful(categoryAddDTO.Name), new ToastrOptions
                {
                    Title = "Başarısız"
                });

            }

            // AddToModelState bunu bizim eklediğimiz extensions ten çağırıyoruz. Dikkat et buraya 
            // Validation işlemi burada bitirmiş oluyoruz artık işleme girmiş oluyor. 
            //var categories = await categoryService.GetAllCategoriesNonDeleted();

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDTO categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddSuccesfull(categoryAddDto.Name), new ToastrOptions
                {
                    Title = "Başarılı"
                });

                return Json("Başarılı");
            }
            else
            {
                toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleAddUnSuccessful(categoryAddDto.Name), new ToastrOptions
                {
                    Title = "Başarısız"
                });
                return Json(result.Errors.First().ErrorMessage);
            }
        }
        // update işlemi 
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryById(categoryId);

            var map = mapper.Map<Category, CategoryUpdateDTO>(category);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            var map = mapper.Map<Category>(categoryUpdateDTO);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDTO);
                toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateSuccesfull(categoryUpdateDTO.Name), new ToastrOptions
                {
                    Title = "Başarılı"
                });
                return RedirectToAction("Index", "Category", new { Areas = "Admin" });

            }
            result.AddToModelState(this.ModelState);

            return View();
        }

        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var deleteCategory = await categoryService.SafeDeleteCategoryAsync(categoryId);


            toastNotification.AddWarningToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleDeleteSuccessful(deleteCategory), new ToastrOptions
            {
                Title = "Başarılı"
            });

            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            await categoryService.UndoDeleteCategoryAsync(categoryId);
            toastNotification.AddWarningToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleDeleteSuccessful("Arşive başarılı bir şekilde alındı"), new ToastrOptions
            {
                Title = "Başarılı"
            });

            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        }



    }
}
