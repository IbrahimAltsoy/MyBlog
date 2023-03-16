using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.ViewComponents.HomeCategory
{
    public class HomeCategory:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _categoryService.GetAllNonDeletedCategoriesTake12();
            int a = 5;
            return View(model);
        }

    }
}
