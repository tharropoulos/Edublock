using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edublock.Migrations
{
    public partial class AddRequestLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AspNetUsers_UserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestStatus_Departments_DepartmentId",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "RequestStatus",
                newName: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_RequestStatus_DepartmentId",
                table: "RequestStatuses",
                newName: "IX_RequestStatuses_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_UserId",
                table: "Requests",
                newName: "IX_Requests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestStatusId",
                table: "Requests",
                newName: "IX_Requests_RequestStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RequestsLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CurrentRequestStatusId = table.Column<int>(type: "int", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsLog_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestsLog_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestsLog_RequestId",
                table: "RequestsLog",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsLog_RequestStatusId",
                table: "RequestsLog",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStatuses_Departments_DepartmentId",
                table: "RequestStatuses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestStatuses_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestStatuses_Departments_DepartmentId",
                table: "RequestStatuses");

            migrationBuilder.DropTable(
                name: "RequestsLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "RequestStatus");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_RequestStatuses_DepartmentId",
                table: "RequestStatus",
                newName: "IX_RequestStatus_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_UserId",
                table: "Request",
                newName: "IX_Request_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Request",
                newName: "IX_Request_RequestStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AspNetUsers_UserId",
                table: "Request",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestStatus_Departments_DepartmentId",
                table: "RequestStatus",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
