using Blog.Entity.DTOS.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blog.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        //Task<UserProfileDto> GetUserProfileAsync();
        //Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
    }
}
