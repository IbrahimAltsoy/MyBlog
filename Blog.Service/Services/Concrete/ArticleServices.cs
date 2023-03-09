using AutoMapper;
using Blog.Data.UnitOfWork;
using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensitions;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Service.Services.Concrete
{
    public class ArticleServices : IArticleServices
    {
        private readonly IUnitOfWorked _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleServices(IUnitOfWorked unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDTO articleaddDTO)
        {
            //var userId = Guid.Parse("4A2EC830-70B3-4158-9392-995C592DFE36");
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await imageHelper.Upload(articleaddDTO.Title, articleaddDTO.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleaddDTO.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            //var imageId = Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD");

            var article = new Article(articleaddDTO.Title, articleaddDTO.Content, userId,userEmail, articleaddDTO.CategoryId,image.Id);
            
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();

        }

        

        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsycn()
        {
            var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);

            var map = _mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }
        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryUnDeletedAsycn()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);

            var map = _mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }
        public async Task<ArticleDTO>GetArticleWithCategoryNonDeletedAsycn( Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id==articleId, x => x.Category, i => i.Image);

            var map = _mapper.Map<ArticleDTO>(article);

            return map;
        }
        public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDTO.Id, x => x.Category, i => i.Image);

            var userEmail = _user.GetLoggedInEmail();

            if (articleUpdateDTO.Photo!=null)
            {
                imageHelper.Delete(article.Image.FillName);
                var imageUpload = await imageHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDTO.Photo.ContentType, userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);
                article.ImageId = image.Id;
            }
            article.Title = articleUpdateDTO.Title;
            article.Content= articleUpdateDTO.Content;
            article.CategoryId= articleUpdateDTO.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();         
           

        }
        public async Task SafeArticleDeleteAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted= true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }
        public async Task UndoArticleUnDeleteAsync(Guid articleId)
        {
           
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = false;
            article.DeletedDate =null;
            article.DeletedBy = null;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

    }
}
