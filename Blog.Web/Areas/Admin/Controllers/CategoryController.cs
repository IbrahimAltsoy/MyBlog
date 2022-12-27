using AutoMapper;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Controllers
{
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
        // update işlemi 
        //[HttpGet]
        //public async Task<IActionResult> Update(Guid categoryId)
        //{
        //    var category = await categoryService.GetAllCategoriesNonDeleted();
        //    //var categories = await categoryService.GetAllCategoriesNonDeleted();
        //    var categoryUpdateDto = mapper.Map<CategoryUpdateDTO>(category);

        //    return View(categoryUpdateDto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        //{
        //    var map = mapper.Map<Category>(categoryUpdateDTO);
        //    var result = await validator.ValidateAsync(map);
        //    if (result.IsValid)
        //    {
        //        await categoryService.UpdateCategoryleAsync(categoryUpdateDTO);
        //        toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateSuccesfull(categoryUpdateDTO.Name), new ToastrOptions
        //        {
        //            Title = "Başarılı"
        //        });
        //        return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        //    }
        //    else
        //    {
        //        result.AddToModelState(this.ModelState);
        //        toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.Article.ArticleUpdateUnSuccessful(categoryUpdateDTO.Name), new ToastrOptions
        //        {
        //            Title = "Başarısız"
        //        });
        //    }
        //    //var categories = await categoryService.GetAllCategoriesNonDeleted();
        //    //categoryService.categories = categories;
        //    return View(categoryUpdateDTO);





        //}
    
        
    }
}
