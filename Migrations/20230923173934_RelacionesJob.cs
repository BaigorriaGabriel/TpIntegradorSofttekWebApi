using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpIntegradorSofttek.Migrations
{
    public partial class RelacionesJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectCodProject",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceCodService",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectCodProject",
                table: "Jobs",
                column: "ProjectCodProject");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ServiceCodService",
                table: "Jobs",
                column: "ServiceCodService");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Projects_ProjectCodProject",
                table: "Jobs",
                column: "ProjectCodProject",
                principalTable: "Projects",
                principalColumn: "codProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Services_ServiceCodService",
                table: "Jobs",
                column: "ServiceCodService",
                principalTable: "Services",
                principalColumn: "codService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Projects_ProjectCodProject",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Services_ServiceCodService",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ProjectCodProject",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ServiceCodService",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProjectCodProject",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ServiceCodService",
                table: "Jobs");
        }
    }
}
