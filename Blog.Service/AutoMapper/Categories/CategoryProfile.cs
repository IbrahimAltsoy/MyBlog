using AutoMapper;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();
            CreateMap<CategoryAddDTO, Category>().ReverseMap();

        }
    }
}
