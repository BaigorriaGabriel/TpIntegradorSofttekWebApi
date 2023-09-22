using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class TechOil3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUser",
                keyValue: 1,
                column: "password",
                value: "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUser",
                keyValue: 2,
                column: "password",
                value: "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUser",
                keyValue: 1,
                column: "password",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "codUser",
                keyValue: 2,
                column: "password",
                value: "1234");
        }
    }
}
