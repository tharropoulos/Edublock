using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edublock.Migrations
{
    public partial class CertificateToRequestLinkRequestToDepartmentLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DepartmentId",
                table: "Requests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_RequestId",
                table: "Certificates",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Requests_RequestId",
                table: "Certificates",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Requests_RequestId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DepartmentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_RequestId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Certificates");
        }
    }
}
