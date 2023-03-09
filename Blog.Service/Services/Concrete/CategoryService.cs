using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
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
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var categories = await unitOfWorked.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories);

            return map;

        }
        public async Task<List<CategoryDTO>> GetAllCategoriesDeleted()
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var categories = await unitOfWorked.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories);

            return map;

        }
        public Task CreateCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            
            var userEmail = _user.GetLoggedInEmail();
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

            var userEmail = _user.GetLoggedInEmail();
            category.Name = categoryUpdateDTO.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await unitOfWorked.GetRepository<Category>().UpdateAsync(category);
            await unitOfWorked.SaveAsync();

           
            return category.Name;

        }
        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {

            var userEmail = _user.GetLoggedInEmail();


            var category = await unitOfWorked.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await unitOfWorked.GetRepository<Category>().UpdateAsync(category);
            await unitOfWorked.SaveAsync();
            return category.Name;
        }
        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            var category = await unitOfWorked.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            await unitOfWorked.GetRepository<Category>().UpdateAsync(category);
            await unitOfWorked.SaveAsync();
            return category.Name;
        }
        //public async Task UndoArticleUnDeleteAsync(Guid articleId)
        //{

        //    var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
        //    article.IsDeleted = false;
        //    article.DeletedDate = null;
        //    article.DeletedBy = null;
        //    await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        //    await _unitOfWork.SaveAsync();
        //}

    }
}
