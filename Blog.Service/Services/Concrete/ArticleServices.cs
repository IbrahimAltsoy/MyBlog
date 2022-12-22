using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Articles;
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
            var imageId = Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD");
            var article = new Article(articleaddDTO.Title, articleaddDTO.Content, userId, articleaddDTO.CategoryId,imageId);
            
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();

        }

        

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsycn()
        {
            var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);

            var map = _mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }
        public async Task<ArticleDTO>GetArticleWithCategoryNonDeletedAsycn( Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id==articleId, x => x.Category);

            var map = _mapper.Map<ArticleDTO>(article);

            return map;
        }
        public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDTO.Id, x => x.Category);
            
            article.Title = articleUpdateDTO.Title;
            article.Content= articleUpdateDTO.Content;
            article.CategoryId= articleUpdateDTO.CategoryId;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();         
           

        }
        public async Task SafeArticleDeleteAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted= true;
            article.DeletedDate = DateTime.Now;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

    }
}
