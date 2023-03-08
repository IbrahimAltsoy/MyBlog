using Blog.Service.FluentValidation;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace Blog.Service.Extensitions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServicesLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

                
            services.AddScoped<IArticleServices, ArticleServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();// servis için eklendi
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(assembly);


            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");

            });
            // Fluent validation için eklenen servic kodlarıdır. 
            return services;
        }

    }
}
