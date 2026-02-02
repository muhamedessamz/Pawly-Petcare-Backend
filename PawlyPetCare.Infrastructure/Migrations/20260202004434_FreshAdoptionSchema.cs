using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FreshAdoptionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Traits",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Breed", "CreatedAt", "Description", "Gender", "Image", "Location", "Name", "Size", "Status", "Traits", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, 2, "Golden Retriever", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(7638), "Max is a happy-go-lucky Golden Retriever who loves to swim and play fetch.", "Male", "https://images.unsplash.com/photo-1552053831-71594a27632d?auto=format&fit=crop&q=80&w=800", "Cairo, Egypt", "Max", "Large", "Approved", "Friendly, Energetic, Loyal", "Dog", "30kg" },
                    { 2, 1, "Persian", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(9287), "Luna is a beautiful Persian cat with a very sweet and quiet personality.", "Female", "https://images.unsplash.com/photo-1514888286974-6c03e2ca1dba?auto=format&fit=crop&q=80&w=800", "Alexandria, Egypt", "Luna", "Small", "Approved", "Calm, Gentle, Affectionate", "Cat", "4kg" },
                    { 3, 3, "German Shepherd", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(9290), "Rocky is a highly intelligent German Shepherd who needs an active home.", "Male", "https://images.unsplash.com/photo-1589941013453-ec89f33b5e95?auto=format&fit=crop&q=80&w=800", "Giza, Egypt", "Rocky", "Large", "Approved", "Protective, Intelligent, Active", "Dog", "35kg" },
                    { 4, 4, "Beagle", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(9330), "Milo is a classic Beagle who loves sniffing out new adventures.", "Male", "https://images.unsplash.com/photo-1537151608828-ea2b11777ee8?auto=format&fit=crop&q=80&w=800", "Cairo, Egypt", "Milo", "Medium", "Approved", "Playful, Curious, Happy", "Dog", "12kg" },
                    { 5, 2, "Siamese", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(9440), "Bella is a social Siamese cat who loves to be the center of attention.", "Female", "https://images.unsplash.com/photo-1513245543132-31f507417b26?auto=format&fit=crop&q=80&w=800", "Mansoura, Egypt", "Bella", "Small", "Approved", "Vocal, Smart, Social", "Cat", "3.5kg" },
                    { 6, 1, "Poodle", new DateTime(2026, 2, 2, 0, 44, 33, 875, DateTimeKind.Utc).AddTicks(9442), "Charlie is a charming little poodle who is great with children.", "Male", "https://images.unsplash.com/photo-1516734212186-a967f81ad0d7?auto=format&fit=crop&q=80&w=800", "Cairo, Egypt", "Charlie", "Small", "Approved", "Hypoallergenic, Elegant, Fun", "Dog", "6kg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Traits",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pets");
        }
    }
}
