using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboard;
        public IActionResult Index()
        {
            return View();
        }
    }
}
