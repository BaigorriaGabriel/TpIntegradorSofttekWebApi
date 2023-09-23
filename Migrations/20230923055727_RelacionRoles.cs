using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class RelacionRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_roleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Roles",
                newName: "id");
        }
    }
}
