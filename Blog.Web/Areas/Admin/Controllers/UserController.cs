using AutoMapper;
using Blog.Entity.DTOS.Users;
using Blog.Entity.Entities;
using Blog.Service.Extensitions;
using Blog.Service.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<AppUser> _validator;

        public UserController(UserManager<AppUser> userManager, IMapper mapper,RoleManager<AppRole> roleManager, IToastNotification toastNotification, IUserService userService, IValidator<AppUser> validator)
        {
            this._userManager = userManager;
            this.mapper = mapper;
            this._roleManager = roleManager;
            _toastNotification = toastNotification;
            _userService = userService;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDTO>>(users);
            foreach(var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join ("",await _userManager.GetRolesAsync(findUser));
                item.Role = role;
            }
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles =await _roleManager.Roles.ToListAsync();
            return View(new UserAddDTO { Roles = roles});
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            var map = mapper.Map<AppUser>(userAddDTO);
            var roles = await _roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                map.UserName = map.Email;
                var result = await _userManager.CreateAsync(map, userAddDTO.Password);
                if (result.Succeeded)
                {
                    var findRole = await _roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());
                    _toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.User.UserAddSuccesfull(userAddDTO.Email), new ToastrOptions
                    {
                        Title = "Başarılı"
                    });
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        _toastNotification.AddErrorToastMessage(ToastrMessaje.ToastrMessage.User.UserAddUnSuccessful(userAddDTO.Email), new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                        return View(new UserAddDTO { Roles = roles });
                    }
                }
            }
           
            return View(new UserAddDTO { Roles = roles });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.GetAppUserByIdAsync(userId);

            var roles = await _userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDTO>(user);
            int a = 5;
            map.Roles = roles;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDto)
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                var roles = await _userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {                           
                            _toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.User.UserAddSuccesfull(userUpdateDto.Email), new ToastrOptions
                            {
                                Title = "Başarılı"
                            });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDTO { Roles = roles });
                        }
                    }
                    else
                    {                        
                        validation.AddToModelState(ModelState);
                        return View(new UserUpdateDTO { Roles = roles });
                    }
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await _userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(ToastrMessaje.ToastrMessage.User.UserDeleteSuccessful(result.email), new ToastrOptions
                {
                    Title = "Başarılı"
                });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Profile(Guid userId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserProfileDTO>(user);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    _toastNotification.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();
                    _toastNotification.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                    return View(profile);
                }
            }
            else
                return NotFound();
        }
        
    }
}
