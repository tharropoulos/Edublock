using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edublock.Migrations
{
    public partial class UserUniversityDepartmentLink_ApplicationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserUniversityDepartmentLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUniversityLinkId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUniversityDepartmentLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUniversityDepartmentLinks_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUniversityDepartmentLinks_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUniversityDepartmentLinks_UserUniversityLinks_UserUniversityLinkId",
                        column: x => x.UserUniversityLinkId,
                        principalTable: "UserUniversityLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUniversityDepartmentLinks_DepartmentId",
                table: "UserUniversityDepartmentLinks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUniversityDepartmentLinks_RoleId",
                table: "UserUniversityDepartmentLinks",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUniversityDepartmentLinks_UserUniversityLinkId",
                table: "UserUniversityDepartmentLinks",
                column: "UserUniversityLinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUniversityDepartmentLinks");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetRoles");
        }
    }
}
