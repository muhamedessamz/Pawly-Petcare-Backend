using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePetSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(3328), "adopt@pawly.com", "+1 (555) 010-1010" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5483), "adopt@pawly.com", "+1 (555) 020-2020" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5490), "adopt@pawly.com", "+1 (555) 030-3030" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5493), "adopt@pawly.com", "+1 (555) 040-4040" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5495), "adopt@pawly.com", "+1 (555) 050-5050" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 8, 15, 23, 12, DateTimeKind.Utc).AddTicks(5498), "adopt@pawly.com", "+1 (555) 060-6060" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(3614), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(5168), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(5171), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(5175), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(5176), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 7, 59, 27, 943, DateTimeKind.Utc).AddTicks(5178), null, null });
        }
    }
}
