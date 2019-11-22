using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STSys.Core.Data.Context.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("b1e6856e-28c7-4e12-88cc-d451707b5e80"));

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColumnName = table.Column<string>(nullable: true),
                    ColumnEName = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ColumnType = table.Column<int>(nullable: true),
                    Tab = table.Column<string>(nullable: true),
                    DataSource = table.Column<int>(nullable: true),
                    Source = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    ProId = table.Column<int>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ColumnId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Intro = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    TabId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommend", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Account", "Address", "Content", "CreateTime", "Email", "Encrypt", "LastTime", "Mobile", "Name", "Password", "PicUrl", "QQ", "Status" },
                values: new object[] { new Guid("26e5e86e-2efc-48c9-aad0-9d1f70327057"), "xxtk", "重庆", null, new DateTime(2019, 10, 16, 14, 28, 35, 424, DateTimeKind.Local).AddTicks(6062), "xxtk@163.com", "123", null, "13512341234", "张三", "CBC33BED3530501DCE65D6FD65C669222A0EDA521A56E3B90489E71FB3EE142E", "", "123456", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "Recommend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("26e5e86e-2efc-48c9-aad0-9d1f70327057"));

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Account", "Address", "Content", "CreateTime", "Email", "Encrypt", "LastTime", "Mobile", "Name", "Password", "PicUrl", "QQ", "Status" },
                values: new object[] { new Guid("b1e6856e-28c7-4e12-88cc-d451707b5e80"), "xxtk", "重庆", null, new DateTime(2019, 10, 10, 8, 41, 57, 230, DateTimeKind.Local).AddTicks(4468), "xxtk@163.com", "123", null, "13512341234", "张三", "123qwe", "", "123456", 0 });
        }
    }
}
