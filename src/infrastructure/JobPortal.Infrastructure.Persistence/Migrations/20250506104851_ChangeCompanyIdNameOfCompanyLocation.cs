using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCompanyIdNameOfCompanyLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "company_location",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_company_location_CompanyId",
                table: "company_location",
                newName: "IX_company_location_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "company_location",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_company_location_company_id",
                table: "company_location",
                newName: "IX_company_location_CompanyId");
        }
    }
}
