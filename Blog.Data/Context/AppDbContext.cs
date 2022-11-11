using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore; u ekleyince bunların silinmesi gerekiyor, bunu installe ttiğmizde bunlar durursa hata oluşturur 

namespace Blog.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet <Article> Articles { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Image> Images { get; set; }

    }
}
