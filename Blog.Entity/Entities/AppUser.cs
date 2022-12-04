﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser: IdentityUser<Guid> 
    {
        public string FirstNAme { get; set; }
        public string LastName { get; set; }
    }
}
