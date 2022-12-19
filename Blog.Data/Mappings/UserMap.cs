using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            
                var nurdan = new AppUser {
                    Id = Guid.Parse("4A2EC830-70B3-4158-9392-995C592DFE36"),
                    UserName = "nurdan@gmail.com",
                    NormalizedUserName = "NURDAN@GMAIL.COM",
                    Email = "nurdan@gmail.com",
                    NormalizedEmail = "NURDAN@GMAIL.COM",
                    PhoneNumber = "+0905444444444",
                    FirstNAme = "Nurdan",
                    LastName = "Cengiz",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ImageId = Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD")


                };
            nurdan.PasswordHash = CreatePasswordHash(nurdan, "123456789");
            var admin = new AppUser
            {
                Id = Guid.Parse("6E147234-3D55-4E06-92A8-725213691A3A"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+0905444444455",
                FirstNAme = "admin",
                LastName = "user",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("8690CF81-8F32-4EC4-A1A2-09CB71B7FFFF")


            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");
            builder.HasData(nurdan, admin);




        }
        private string CreatePasswordHash(AppUser appUser, string password)
        {
            var passwordHash = new PasswordHasher<AppUser>();
            return passwordHash.HashPassword(appUser, password);
        }
    }
}
