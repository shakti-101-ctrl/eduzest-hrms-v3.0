using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eduzest.HRMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserIdChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsrerId",
                table: "Registrations",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Registrations",
                newName: "UsrerId");
        }
    }
}
