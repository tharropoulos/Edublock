using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edublock.Migrations
{
    public partial class ChangeRequestLogTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLog_Requests_RequestId",
                table: "RequestsLog");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLog_RequestStatuses_RequestStatusId",
                table: "RequestsLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsLog",
                table: "RequestsLog");

            migrationBuilder.RenameTable(
                name: "RequestsLog",
                newName: "RequestsLogs");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLog_RequestStatusId",
                table: "RequestsLogs",
                newName: "IX_RequestsLogs_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLog_RequestId",
                table: "RequestsLogs",
                newName: "IX_RequestsLogs_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsLogs",
                table: "RequestsLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLogs_Requests_RequestId",
                table: "RequestsLogs",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLogs_RequestStatuses_RequestStatusId",
                table: "RequestsLogs",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLogs_Requests_RequestId",
                table: "RequestsLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsLogs_RequestStatuses_RequestStatusId",
                table: "RequestsLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsLogs",
                table: "RequestsLogs");

            migrationBuilder.RenameTable(
                name: "RequestsLogs",
                newName: "RequestsLog");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLogs_RequestStatusId",
                table: "RequestsLog",
                newName: "IX_RequestsLog_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsLogs_RequestId",
                table: "RequestsLog",
                newName: "IX_RequestsLog_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsLog",
                table: "RequestsLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLog_Requests_RequestId",
                table: "RequestsLog",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsLog_RequestStatuses_RequestStatusId",
                table: "RequestsLog",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");
        }
    }
}
