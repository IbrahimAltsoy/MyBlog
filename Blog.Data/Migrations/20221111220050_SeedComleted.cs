using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedComleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(1143), "10-10-2019", null, false, "Erkan", null, "Visual Studio 2022" },
                    { new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(1139), "10-04-2021", null, false, "Ersin", null, "ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FillName", "FillType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(1291), "09-10-2020", null, "images/vstest", "png", false, "Nurdan", null },
                    { new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(1287), "10-10-2020", null, "images/testimage", "jpg", false, "Ibrahim", null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8bc2c2ce-7c8a-4d9d-a2b3-f48c3175c409"), new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(885), "10-10-2020", null, new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), false, "Huseyin", null, "Visual Studio Deneme MAkalesi", 21 },
                    { new Guid("bdcc2904-cf9e-4979-9a71-1b125a3e1bfe"), new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Admin Test", new DateTime(2022, 11, 12, 1, 0, 49, 786, DateTimeKind.Local).AddTicks(867), "10-10-2020", null, new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), false, "Necdet", null, "Asp.Net Core Deneme Makalesi", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8bc2c2ce-7c8a-4d9d-a2b3-f48c3175c409"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bdcc2904-cf9e-4979-9a71-1b125a3e1bfe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
