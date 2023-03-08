using Blog.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Entity.DTOS.Users
{
    public class UserAddDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public Guid RoleId { get; set; }       
        public List<AppRole> Roles { get;set; }
    }
}
