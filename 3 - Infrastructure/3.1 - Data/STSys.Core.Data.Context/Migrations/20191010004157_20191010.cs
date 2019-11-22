using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STSys.Core.Data.Context.Migrations
{
    public partial class _20191010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("e0fb16cf-96ab-4921-910b-859ac977d057"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Account", "Address", "Content", "CreateTime", "Email", "Encrypt", "LastTime", "Mobile", "Name", "Password", "PicUrl", "QQ", "Status" },
                values: new object[] { new Guid("b1e6856e-28c7-4e12-88cc-d451707b5e80"), "xxtk", "重庆", null, new DateTime(2019, 10, 10, 8, 41, 57, 230, DateTimeKind.Local).AddTicks(4468), "xxtk@163.com", "123", null, "13512341234", "张三", "123qwe", "", "123456", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("b1e6856e-28c7-4e12-88cc-d451707b5e80"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "users");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Account", "Address", "Content", "CreateTime", "Email", "Encrypt", "LastTime", "Mobile", "Name", "Password", "PicUrl", "QQ", "Status" },
                values: new object[] { new Guid("e0fb16cf-96ab-4921-910b-859ac977d057"), "xxtk", "重庆", null, new DateTime(2019, 10, 10, 8, 33, 28, 768, DateTimeKind.Local).AddTicks(4322), "xxtk@163.com", "123", null, "13512341234", "张三", "123qwe", "", "123456", 0 });
        }
    }
}
