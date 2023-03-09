using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Profilemig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("89ca7863-339f-4a2c-a747-9a93b38ddb5b"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("97cfe007-4f90-4258-9ccd-f3718c11c52b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1a0aac01-a4c9-4b69-8223-a8de34fa100d"), new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Admin Test", new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(2172), "10-10-2020", null, new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), false, "Necdet", null, "Asp.Net Core Deneme Makalesi", new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"), 10 },
                    { new Guid("fbf69a70-724a-4c9b-884b-1e2f1393369a"), new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Admin Test", new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(2193), "10-10-2020", null, new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), false, "Huseyin", null, "Visual Studio Deneme MAkalesi", new Guid("6e147234-3d55-4e06-92a8-725213691a3a"), 21 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640e6eee-52a9-4900-9f16-48b349c76266"),
                column: "ConcurrencyStamp",
                value: "9893d94e-5d52-47af-96a4-576dcf3ea7f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b1ade65-892e-4314-bf64-6572c8d63a29"),
                column: "ConcurrencyStamp",
                value: "3d53af60-fa72-4079-a4df-caea76112eb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92705811-704b-4292-9be2-eab8124ae245"),
                column: "ConcurrencyStamp",
                value: "41e77a5b-1549-4acd-aa88-b219b0a06452");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ff9f705-3d14-42d2-bb00-0ec7d55719b2"),
                column: "ConcurrencyStamp",
                value: "049ecbfd-b287-4c65-a5cf-c1f5a871fe87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a23b541-c3d0-4806-a2b7-2872e60f8547", "AQAAAAIAAYagAAAAEAt50s/SB2AYB6NPLHtICC8i7ZGtFiq6LsGUytMHLu/nds64rxHLIKwKlGaoaSmASg==", "43accff9-ccf3-42ab-b4d6-3f7195971706" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e147234-3d55-4e06-92a8-725213691a3a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21813307-65c1-405f-9015-c72a46b3faca", "AQAAAAIAAYagAAAAEPQTF2KXrHHBuSu0PMWdjTe8m5Mu5g1SGEN9VOgAyRe0WAQe/ZuZNJGcvN8+aXakTw==", "1f7f8e1c-044a-4907-b03c-9654e49dfeab" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 1, 41, 11, 674, DateTimeKind.Local).AddTicks(4953));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1a0aac01-a4c9-4b69-8223-a8de34fa100d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fbf69a70-724a-4c9b-884b-1e2f1393369a"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("89ca7863-339f-4a2c-a747-9a93b38ddb5b"), new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Admin Test", new DateTime(2022, 12, 22, 0, 36, 51, 190, DateTimeKind.Local).AddTicks(8227), "10-10-2020", null, new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"), false, "Necdet", null, "Asp.Net Core Deneme Makalesi", new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"), 10 },
                    { new Guid("97cfe007-4f90-4258-9ccd-f3718c11c52b"), new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"), "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Admin Test", new DateTime(2022, 12, 22, 0, 36, 51, 190, DateTimeKind.Local).AddTicks(8237), "10-10-2020", null, new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"), false, "Huseyin", null, "Visual Studio Deneme MAkalesi", new Guid("6e147234-3d55-4e06-92a8-725213691a3a"), 21 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("640e6eee-52a9-4900-9f16-48b349c76266"),
                column: "ConcurrencyStamp",
                value: "fe24699b-b22f-4094-ad41-b43a19ed6b8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b1ade65-892e-4314-bf64-6572c8d63a29"),
                column: "ConcurrencyStamp",
                value: "6973e40c-e74e-43ba-bb71-1d24223f4052");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92705811-704b-4292-9be2-eab8124ae245"),
                column: "ConcurrencyStamp",
                value: "499cd0e6-6f48-4343-90ab-be619bb8603e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ff9f705-3d14-42d2-bb00-0ec7d55719b2"),
                column: "ConcurrencyStamp",
                value: "33c0ea94-1473-409f-aa10-7f3f1da4a14a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a2ec830-70b3-4158-9392-995c592dfe36"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "638fc36c-248e-4d48-9d22-bc299cec5fc7", "AQAAAAIAAYagAAAAEDB5uEeR8VYLOio9xDq3armFokkg5N5FlU+1RICad4ggaB3HC6wM8JI5TUXJa2K1/Q==", "73e864cd-f2c4-4ba5-9085-1b7927e6b791" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e147234-3d55-4e06-92a8-725213691a3a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4488104d-69e0-4d7e-a560-211bbec5236e", "AQAAAAIAAYagAAAAEPvLig2hgB74kWKdkwOjYHJeRCpSj8mGKNlOxCEFAngkqcTfo+q8V1QuORyebfs4BA==", "d23a0f67-38cb-4da0-9828-d029c7ddc450" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa1e766b-7ce2-4d98-98c0-e58de51c003e"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 36, 51, 190, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9c94b84-33a4-4872-b3ae-ec1daab3be00"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 36, 51, 190, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8690cf81-8f32-4ec4-a1a2-09cb71b7ffff"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 36, 51, 191, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0cbe860-d7a6-4a6a-954a-9b99dcc1f3bd"),
                column: "CreatedDate",
                value: new DateTime(2022, 12, 22, 0, 36, 51, 191, DateTimeKind.Local).AddTicks(1110));
        }
    }
}
