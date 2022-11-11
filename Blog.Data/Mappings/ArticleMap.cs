using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder.Property(x=> x.Title).HasMaxLength(150); bu kodu çalıştırdık 
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.Net Core Deneme Makalesi",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                ViewCount = 10,
                CategoryId = Guid.Parse("E9C94B84-33A4-4872-B3AE-EC1DAAB3BE00"),
                ImageId = Guid.Parse("C0CBE860-D7A6-4A6A-954A-9B99DCC1F3BD"),
                CreatedBy = "Admin Test",
                ModifiedBy = "Necdet",
                DeletedBy = "10-10-2020",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme MAkalesi",
                Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                ViewCount =21,
                CategoryId = Guid.Parse("AA1E766B-7CE2-4D98-98C0-E58DE51C003E"),
                ImageId = Guid.Parse("8690CF81-8F32-4EC4-A1A2-09CB71B7FFFF"),
                CreatedBy = "Admin Test",
                ModifiedBy = "Huseyin",
                DeletedBy = "10-10-2020",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });

        }
    }
}
