﻿using Blog.Entity.DTOS.Articles;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface IArticleServices
    {
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsycn();
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryUnDeletedAsycn();
        Task CreateArticleAsync(ArticleAddDTO articleDTO);
        Task<ArticleDTO> GetArticleWithCategoryNonDeletedAsycn(Guid articleId);
        Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO);
        Task SafeArticleDeleteAsync(Guid articleId);
        Task UndoArticleUnDeleteAsync(Guid articleId);
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);

    }
}
