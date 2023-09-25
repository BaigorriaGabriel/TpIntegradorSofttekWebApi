using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class FKJobs24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    codService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    hourValue = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
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
                    roleId = table.Column<int>(type: "Int", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.codUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    codJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codProject = table.Column<int>(type: "int", nullable: false),
                    codService = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amountHours = table.Column<int>(type: "int", nullable: false),
                    hourValue = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.codJob);
                    table.ForeignKey(
                        name: "FK_Jobs_Projects_codProject",
                        column: x => x.codProject,
                        principalTable: "Projects",
                        principalColumn: "codProject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Services_codService",
                        column: x => x.codService,
                        principalTable: "Services",
                        principalColumn: "codService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roleId", "description", "isActive", "name" },
                values: new object[] { 1, "Admin", true, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roleId", "description", "isActive", "name" },
                values: new object[] { 2, "Consultant", true, "Consultant" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUser", "dni", "email", "isActive", "name", "password", "roleId" },
                values: new object[] { 1, "44504788", "gabi.2912@hotmail.com", true, "Gabriel Baigorria", "162e9a2c1909da1a9351ceb62011fc82826128f10a56044433681aba5826b972", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "codUser", "dni", "email", "isActive", "name", "password", "roleId" },
                values: new object[] { 2, "45000001", "feli.2003@hotmail.com", true, "Felipe Morato", "e13fe3c24eca2a7180b5b88b6932420e99c4b5b916cb4674319102abebe12bb3", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_codProject",
                table: "Jobs",
                column: "codProject");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_codService",
                table: "Jobs",
                column: "codService");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
