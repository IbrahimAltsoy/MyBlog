using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("49723966-2876-4c99-b11e-7e9028153c68"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a2246b97-04c2-4b2d-8277-4eab3ad23e77"));

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("4aae6a32-5e26-46d2-81df-5ccd8ef13af5"), new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Admin Test", new DateTime(2022, 12, 22, 0, 35, 17, 975, DateTimeKind.Local).AddTicks(8757), "10-10-2020", null, new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), false, "Huseyin", null, "Visual Studio Deneme MAkalesi", new Guid("6e147234-3d55-4e06-92a8-725213691a3a"), 21 },
                    { new Guid("8e7c0e8f-77e9-4a43-a961-922fbe5d6f0d"), new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Admin Test", new DateTime(2022, 12, 22, 0, 35, 17, 975, DateTimeKind.Local).AddTicks(8748), "10-10-2020", null, new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), false, "Necdet", null, "Asp.Net Core Deneme Makalesi", new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640e6eee-52a9-4900-9f16-48b349c76266"),
                column: "ConcurrencyStamp",
                value: "cfb36de2-413a-4d69-8a47-22903fdd2257");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b1ade65-892e-4314-bf64-6572c8d63a29"),
                column: "ConcurrencyStamp",
                value: "90d582cf-70ba-4b62-b049-5504abcdcef8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92705811-704b-4292-9be2-eab8124ae245"),
                column: "ConcurrencyStamp",
                value: "86b8df59-766f-4f2e-8806-42d7720fc0cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ff9f705-3d14-42d2-bb00-0ec7d55719b2"),
                column: "ConcurrencyStamp",
                value: "11a21bd0-1d02-4793-ab0c-3c44b12adb90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a2124d5-90c5-47f9-8859-8dafa12a83b2", "AQAAAAIAAYagAAAAEDmAzoOXakzGTz5XdTulD52TUECers18Bk0zLGtBdIILLZDqEBSnf2u3UnmqI6ioFg==", "b7c46e3d-b30e-455f-8dba-3a1a73992d17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e147234-3d55-4e06-92a8-725213691a3a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8305447b-2e6d-4aad-aa0f-d082906a4d73", "AQAAAAIAAYagAAAAED4CJPm1cdGzzX/DxCZFkeCUDP023H/Ka5HLEXVCaEZ8bZNkXqJCxS1ATfXWQgWPGA==", "09426fbb-3ba7-48ed-a7a8-07d71b51daed" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 35, 17, 976, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 35, 17, 976, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 35, 17, 976, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 35, 17, 976, DateTimeKind.Local).AddTicks(1605));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4aae6a32-5e26-46d2-81df-5ccd8ef13af5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8e7c0e8f-77e9-4a43-a961-922fbe5d6f0d"));

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("49723966-2876-4c99-b11e-7e9028153c68"), new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Admin Test", new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(4678), "10-10-2020", null, new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), false, "Necdet", null, "Asp.Net Core Deneme Makalesi", new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"), 10 },
                    { new Guid("a2246b97-04c2-4b2d-8277-4eab3ad23e77"), new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Admin Test", new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(4687), "10-10-2020", null, new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), false, "Huseyin", null, "Visual Studio Deneme MAkalesi", new Guid("6e147234-3d55-4e06-92a8-725213691a3a"), 21 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640e6eee-52a9-4900-9f16-48b349c76266"),
                column: "ConcurrencyStamp",
                value: "734b483c-5a4d-4389-af47-2cb42eccb9dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b1ade65-892e-4314-bf64-6572c8d63a29"),
                column: "ConcurrencyStamp",
                value: "efd8d6c2-6717-4995-86de-33868f7a6bf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92705811-704b-4292-9be2-eab8124ae245"),
                column: "ConcurrencyStamp",
                value: "089b9b22-8772-465d-88d0-1e839dc5e12c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ff9f705-3d14-42d2-bb00-0ec7d55719b2"),
                column: "ConcurrencyStamp",
                value: "dfc6e476-c47a-4872-a7b6-d593eb812f38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60417eec-a681-4732-9918-32bf484272cf", "AQAAAAIAAYagAAAAEBLVgWBao/+VHsPEqH1ow4Z+tRpu0tprHXSpsgak9Sx+z5luS6Qn6MjfNsauFa3SFw==", "9425b3e4-212e-402e-9f47-5150e9ec44bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e147234-3d55-4e06-92a8-725213691a3a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f984612-b82d-4045-b3f8-4a09f3b77e58", "AQAAAAIAAYagAAAAED2WBcgtukz6WWz2XU/QS/yKxbtMo4vOEG8591AWxMGQpyL0KNHUlWU0plCHdiSchg==", "ce9a79e4-521a-4ce4-b2f8-8f9368af3584" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 19, 20, 31, 55, 623, DateTimeKind.Local).AddTicks(7616));
        }
    }
}
