using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace Blog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorked unitOfWorked;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;


        public CategoryService(IUnitOfWorked unitOfWorked,IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWorked = unitOfWorked;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;

        }
        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var userId = _user.GetLeggedInUserId();
            var userEmail = _user.GetLeggedInEmail();
            var categories = await unitOfWorked.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories);

            return map;

        }
        public Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = _user.GetLeggedInEmail();
            Category category = new (categoryAddDTO.Name, userEmail);
           unitOfWorked.GetRepository<Category>().AddAsync(category);
            //unitOfWorked.SaveAsync();
            return unitOfWorked.SaveAsync();
            
        }
        // Update İşlemleri 
        public Task<Category> GetCategoryById(Guid id)
        {
            var category = unitOfWorked.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await unitOfWorked.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDTO.Id);

            var userEmail = _user.GetLeggedInEmail();
            category.Name = categoryUpdateDTO.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await unitOfWorked.GetRepository<Category>().UpdateAsync(category);
            await unitOfWorked.SaveAsync();

           
            return category.Name;

        }
        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {

            var userEmail = _user.GetLeggedInEmail();


            var category = await unitOfWorked.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await unitOfWorked.GetRepository<Category>().UpdateAsync(category);
            await unitOfWorked.SaveAsync();
            return category.Name;
        }


    }
}
