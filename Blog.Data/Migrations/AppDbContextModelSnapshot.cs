﻿// <auto-generated />
using System;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e96b1701-1d9a-48c4-9089-7c0413d7747e"),
                            CategoryId = new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                            Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9180),
                            DeletedBy = "10-10-2020",
                            ImageId = new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                            IsDeleted = false,
                            ModifiedBy = "Necdet",
                            Title = "Asp.Net Core Deneme Makalesi",
                            ViewCount = 10
                        },
                        new
                        {
                            Id = new Guid("82362d15-eb36-4f10-a3ed-fa35372d8581"),
                            CategoryId = new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                            Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9187),
                            DeletedBy = "10-10-2020",
                            ImageId = new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                            IsDeleted = false,
                            ModifiedBy = "Huseyin",
                            Title = "Visual Studio Deneme MAkalesi",
                            ViewCount = 21
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9406),
                            DeletedBy = "10-04-2021",
                            IsDeleted = false,
                            ModifiedBy = "Ersin",
                            Name = "ASP.NET Core"
                        },
                        new
                        {
                            Id = new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9410),
                            DeletedBy = "10-10-2019",
                            IsDeleted = false,
                            ModifiedBy = "Erkan",
                            Name = "Visual Studio 2022"
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FillType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9646),
                            DeletedBy = "10-10-2020",
                            FillName = "images/testimage",
                            FillType = "jpg",
                            IsDeleted = false,
                            ModifiedBy = "Ibrahim"
                        },
                        new
                        {
                            Id = new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2022, 12, 3, 16, 17, 18, 578, DateTimeKind.Local).AddTicks(9652),
                            DeletedBy = "09-10-2020",
                            FillName = "images/vstest",
                            FillType = "png",
                            IsDeleted = false,
                            ModifiedBy = "Nurdan"
                        });
                });

            modelBuilder.Entity("Blog.Entity.Entities.Article", b =>
                {
                    b.HasOne("Blog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Blog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Blog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
