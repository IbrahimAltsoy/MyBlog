using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorked unitOfWorked;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWorked unitOfWorked,IMapper mapper)
        {
            this.unitOfWorked = unitOfWorked;
            this.mapper = mapper;
            
        }
        public async Task<List<CategoryDTO>> GetAllCategoriesNonDeleted()
        {
            var categories = await unitOfWorked.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDTO>>(categories);

            return map;

        }
    }
}
