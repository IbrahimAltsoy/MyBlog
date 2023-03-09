using AutoMapper;
using Blog.Entity.DTOS.Users;
using Blog.Entity.Entities;

namespace Blog.Service.AutoMapper.Users
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, UserAddDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, UserProfileDTO>().ReverseMap();

        }
       

    }
}
