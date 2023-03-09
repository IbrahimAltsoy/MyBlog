using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser: IdentityUser<Guid> , IEntityBase
    {
        public string FirstNAme { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
