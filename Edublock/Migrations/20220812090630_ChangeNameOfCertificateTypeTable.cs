using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edublock.Migrations
{
    public partial class ChangeNameOfCertificateTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_TypeOfCertificates_TypeOfCertificateId",
                table: "Certificates");

            migrationBuilder.DropTable(
                name: "TypeOfCertificates");

            migrationBuilder.RenameColumn(
                name: "TypeOfCertificateId",
                table: "Certificates",
                newName: "CertificateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_TypeOfCertificateId",
                table: "Certificates",
                newName: "IX_Certificates_CertificateTypeId");

            migrationBuilder.CreateTable(
                name: "CertificateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTypes_CertificateTypeId",
                table: "Certificates",
                column: "CertificateTypeId",
                principalTable: "CertificateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTypes_CertificateTypeId",
                table: "Certificates");

            migrationBuilder.DropTable(
                name: "CertificateTypes");

            migrationBuilder.RenameColumn(
                name: "CertificateTypeId",
                table: "Certificates",
                newName: "TypeOfCertificateId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_CertificateTypeId",
                table: "Certificates",
                newName: "IX_Certificates_TypeOfCertificateId");

            migrationBuilder.CreateTable(
                name: "TypeOfCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfCertificates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_TypeOfCertificates_TypeOfCertificateId",
                table: "Certificates",
                column: "TypeOfCertificateId",
                principalTable: "TypeOfCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
