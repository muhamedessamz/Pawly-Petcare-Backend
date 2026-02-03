using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevertMockDataToUS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(6140), "New York, NY" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(8164), "Los Angeles, CA" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(8169), "Chicago, IL" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(8173), "Seattle, WA" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(8175), "Austin, TX" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 20, 50, 596, DateTimeKind.Utc).AddTicks(8177), "Boston, MA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(3328), "Cairo, Egypt" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5483), "Alexandria, Egypt" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5490), "Giza, Egypt" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5493), "Cairo, Egypt" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5495), "Mansoura, Egypt" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Location" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5498), "Cairo, Egypt" });
        }
    }
}
