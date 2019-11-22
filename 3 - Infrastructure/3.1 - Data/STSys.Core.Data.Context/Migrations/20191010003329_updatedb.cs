using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STSys.Core.Data.Context.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    LastTime = table.Column<DateTime>(nullable: true),
                    Encrypt = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    QQ = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PicUrl = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PicUrl = table.Column<string>(nullable: true),
                    Encrypt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Account", "Address", "Content", "CreateTime", "Email", "Encrypt", "LastTime", "Mobile", "Name", "Password", "PicUrl", "QQ", "Status" },
                values: new object[] { new Guid("e0fb16cf-96ab-4921-910b-859ac977d057"), "xxtk", "重庆", null, new DateTime(2019, 10, 10, 8, 33, 28, 768, DateTimeKind.Local).AddTicks(4322), "xxtk@163.com", "123", null, "13512341234", "张三", "123qwe", "", "123456", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
