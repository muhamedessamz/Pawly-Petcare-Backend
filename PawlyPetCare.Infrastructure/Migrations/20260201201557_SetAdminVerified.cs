using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetAdminVerified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsVerified",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsVerified",
                value: false);
        }
    }
}
