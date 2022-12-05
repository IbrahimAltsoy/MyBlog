using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            builder.HasData(new AppRole
            {
                Id = Guid.Parse("92705811-704B-4292-9BE2-EAB8124AE245"),
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            }, new AppRole
            {
                Id = Guid.Parse("640E6EEE-52A9-4900-9F16-48B349C76266"),
                Name = "erkan",
                NormalizedName = "ERKAN",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            }, new AppRole
            {
                Id = Guid.Parse("9FF9F705-3D14-42D2-BB00-0EC7D55719B2"),
                Name = "altsoy",
                NormalizedName = "ALTSOY",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            }, new AppRole
            {
                Id = Guid.Parse("8B1ADE65-892E-4314-BF64-6572C8D63A29"),
                Name = "Ersin",
                NormalizedName = "ERSIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            }
            ) ;
        }
    }
}
