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
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("4A2EC830-70B3-4158-9392-995C592DFE36"),
                RoleId = Guid.Parse("92705811-704B-4292-9BE2-EAB8124AE245")


            },new AppUserRole
            {
                UserId = Guid.Parse("6E147234-3D55-4E06-92A8-725213691A3A"),
                RoleId = Guid.Parse("640E6EEE-52A9-4900-9F16-48B349C76266")

            }
            );
        }
        
    }
}
