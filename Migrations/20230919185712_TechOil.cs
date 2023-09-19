using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class TechOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    codJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    codProject = table.Column<int>(type: "int", nullable: false),
                    codService = table.Column<int>(type: "int", nullable: false),
                    amountHours = table.Column<int>(type: "int", nullable: false),
                    hourValue = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.codJob);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    codProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    address = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.codProject);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    codService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    hourValue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.codService);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    codUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    dni = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    type = table.Column<int>(type: "Int", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.codUser);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUser", "dni", "email", "isActive", "name", "password", "type" },
                values: new object[] { 1, "44504788", "gabi.2912@hotmail.com", true, "Gabriel Baigorria", "1234", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUser", "dni", "email", "isActive", "name", "password", "type" },
                values: new object[] { 2, "45000001", "feli.2003@hotmail.com", true, "Felipe Morato", "1234", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
