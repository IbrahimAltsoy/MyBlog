using Blog.Entity.DTOS.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllCategoriesNonDeleted();
        public Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO);
        //sonradan eklendi
        //public Task UpdateCategoryleAsync(CategoryUpdateDTO categoryUpdateDTO);
    }
}
