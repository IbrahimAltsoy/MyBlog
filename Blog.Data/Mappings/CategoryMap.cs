using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("E9C94B84-33A4-4872-B3AE-EC1DAAB3BE00"),
                Name = "ASP.NET Core",
                CreatedBy = "Admin Test",
                ModifiedBy = "Ersin",
                DeletedBy = "10-04-2021",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            }, new Category
            {
                Id = Guid.Parse("AA1E766B-7CE2-4D98-98C0-E58DE51C003E"),
                Name = "Visual Studio 2022",
                CreatedBy = "Admin Test",
                ModifiedBy = "Erkan",
                DeletedBy = "10-10-2019",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            }

            );


        }
    }
}
