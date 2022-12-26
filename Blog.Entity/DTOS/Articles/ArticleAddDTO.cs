using Blog.Entity.DTOS.Categories;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOS.Articles
{
    public class ArticleAddDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        
        public IFormFile Photo { get; set; }
       
        
        
        public IList<CategoryDTO> categories { get; set; }

    }
}
