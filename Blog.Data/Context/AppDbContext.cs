using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore; bu ekleyince bunların silinmesi gerekiyor, bunu installe ttiğmizde bunlar durursa hata oluşturur.

namespace Blog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        //private readonly DbContextOptions<AppDbContext> _options;

        

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        {
            
        }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            // Burası Article mapta confirgation ettiğimiz yerin diğer tablo üzerinde ve Assembly ile bütün tablolarda yapılmasını sağlayan Kod bloğudur. Burdaki kod akışı ArticleMap ten gelen confirgation işlem sonucu yazdık.
        {
            //builder.Entity<Article>().Property(x => x.Title).HasMaxLength(150); bu kodta çalışır fakat bu clean kod olmaz çünkü bütün değişikler için bu kodu yazdığımızda maliyeti artar performans düşer, bunun yerine aşağıdaki kodu yazdığımızda ArticleMap te ki bütün validation işlemlerini kabulunu gerçekleştirmiş oluruz gibi gibi
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
        }

    }
}
