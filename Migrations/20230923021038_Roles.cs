using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "description", "isActive", "name" },
                values: new object[] { 1, "Admin", true, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "description", "isActive", "name" },
                values: new object[] { 2, "Consultant", true, "Consultant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
