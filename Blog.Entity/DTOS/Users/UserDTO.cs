﻿namespace Blog.Entity.DTOS.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public int AccessFailledCount { get; set; }
        public string Role { get; set; }
    }
}
