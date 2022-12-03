using Blog.Data.UnitOfWork;
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

        public ArticleServices(IUnitOfWorked unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Article>> GetAllArticlesAsycn()
        {
            
            return await _unitOfWork.GetRepository<Article>().GetAllAsync();
        }
    }
}
