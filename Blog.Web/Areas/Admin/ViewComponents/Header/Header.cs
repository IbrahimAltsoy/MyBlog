using AutoMapper;
using Blog.Entity.DTOS.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents.Header
{
    public class Header:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper mapper;

        public Header(UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logged = await _userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserDTO>(logged);
            var role = string.Join("", await _userManager.GetRolesAsync(logged));
            map.Role = role;
            return View(map);
            
        }
    }
}
