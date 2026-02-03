using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerContactToPets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerEmail",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerPhone",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(4706), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(6321), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(6324), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(6326), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(6328), null, null });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OwnerEmail", "OwnerPhone" },
                values: new object[] { new DateTime(2026, 2, 3, 0, 29, 59, 448, DateTimeKind.Utc).AddTicks(6330), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerEmail",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerPhone",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 26, 6, 941, DateTimeKind.Utc).AddTicks(2077));
        }
    }
}
