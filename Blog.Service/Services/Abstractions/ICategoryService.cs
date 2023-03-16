using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
         Task<List<CategoryDTO>> GetAllCategoriesNonDeleted();
         Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO);
        Task<Category> GetCategoryById(Guid id);
        Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<List<CategoryDTO>> GetAllCategoriesDeleted();
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
        Task<List<CategoryDTO>> GetAllNonDeletedCategoriesTake12();

        //sonradan eklendi
        //public Task UpdateCategoryleAsync(CategoryUpdateDTO categoryUpdateDTO);
    }
}
