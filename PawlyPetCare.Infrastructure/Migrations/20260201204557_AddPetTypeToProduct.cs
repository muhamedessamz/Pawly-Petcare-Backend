using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTypeToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Products");
        }
    }
}
