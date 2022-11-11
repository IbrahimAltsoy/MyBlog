using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.HasData(new Image
            {
                Id =Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD"),
                FillName = "images/testimage",
                FillType = "jpg",
                CreatedBy = "Admin Test",
                ModifiedBy = "Ibrahim",
                DeletedBy = "10-10-2020",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            },
            new Image
            {
                Id = Guid.Parse("8690CF81-8F32-4EC4-A1A2-09CB71B7FFFF"),
                FillName = "images/vstest",
                FillType = "png",
                CreatedBy = "Admin Test",
                ModifiedBy = "Nurdan",
                DeletedBy = "09-10-2020",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });

        }
    }
}
