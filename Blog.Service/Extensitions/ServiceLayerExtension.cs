﻿using Blog.Data.Context;
using Blog.Data.Repositories.Abstractions;
using Blog.Data.Repositories.Concretes;
using Blog.Data.UnitOfWork;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensitions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServicesLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

                
            services.AddScoped<IArticleServices, ArticleServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(assembly);
            return services;
        }

    }
}
