using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentHelpers.Migrations
{
    public partial class alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignments_clients_clientId",
                table: "assignments");

            migrationBuilder.DropIndex(
                name: "IX_assignments_clientId",
                table: "assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_assignments_clientId",
                table: "assignments",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_clients_clientId",
                table: "assignments",
                column: "clientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
