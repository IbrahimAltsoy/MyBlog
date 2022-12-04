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

        public async Task<List<ArticleDTO>> GetAllArticlesAsycn()
        {
            var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync();

            var map = _mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }
    }
}
