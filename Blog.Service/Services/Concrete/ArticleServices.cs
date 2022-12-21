using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Service.Services.Concrete
{
    public class ArticleServices : IArticleServices
    {
        private readonly IUnitOfWorked _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleServices(IUnitOfWorked unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddDTO articleaddDTO)
        {
            var userId = Guid.Parse("4A2EC830-70B3-4158-9392-995C592DFE36");
            var article = new Article
            {

                Title = articleaddDTO.Title,
                Content = articleaddDTO.Content,
                CategoryId = articleaddDTO.CategoryId,
                UserId = userId
            };
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();

        }

        

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsycn()
        {
            var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);

            var map = _mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }
    }
}
