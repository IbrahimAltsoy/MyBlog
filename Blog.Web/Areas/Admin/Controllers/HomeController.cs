﻿using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleServices articleService;
        private readonly IDashboardService dashbordService;
       

        public HomeController(IArticleServices articleService, IDashboardService dashbordService)
        {
            this.articleService = articleService;
            this.dashbordService = dashbordService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            var count = await dashbordService.GetYearlyArticleCounts();
            /* dashboardService.GetYearlyArticleCounts();*/
            ViewData["count"] = count;

            return View(articles);
        }
        //[HttpGet]
        //public async Task<IActionResult> YearlyArticleCounts()
        //{
        //var count = await dashbordService.GetYearlyArticleCounts();
        //ViewData["count"] = count;
        //    //Json(JsonConvert.SerializeObject(count));
           
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> TotalArticleCount()
        //{
        //    var count = await dashbordService.GetTotalArticleCount();
        //    return Json(count);
        //}
        //[HttpGet]
        //public async Task<IActionResult> TotalCategoryCount()
        //{
        //    var count = await dashbordService.GetTotalCategoryCount();
        //    return Json(count);
        //}


    }
}
