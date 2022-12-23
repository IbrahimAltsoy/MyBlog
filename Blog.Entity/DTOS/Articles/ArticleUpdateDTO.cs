﻿using Blog.Entity.DTOS.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOS.Articles
{
    public class ArticleUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public IList<CategoryDTO> categories { get; set; }
    }
}