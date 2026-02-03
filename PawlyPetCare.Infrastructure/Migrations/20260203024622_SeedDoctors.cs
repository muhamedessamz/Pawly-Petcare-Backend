using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawlyPetCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Availability", "ExperienceYears", "Image", "Location", "Name", "Rating", "Specialty" },
                values: new object[,]
                {
                    { 1, "Mon,Wed,Fri,Sat", 15, "https://img.freepik.com/free-photo/close-up-health-worker_23-2149112506.jpg?t=st=1769968108~exp=1769971708~hmac=776163d86f26ae815d19154eb6dbe230a0e53b173b9720bffdc9e4a243b970a1", "Pawly Main Clinic", "Dr. Richard Hamilton", 4.9000000000000004, "Senior Veterinary Surgeon" },
                    { 2, "Tue,Thu,Fri", 10, "https://img.freepik.com/free-photo/female-doctor-hospital-with-stethoscope_23-2148827776.jpg?semt=ais_hybrid&w=740&q=80", "Pawly Main Clinic", "Dr. Isabella Rossi", 5.0, "Dermatology & Allergy Specialist" },
                    { 3, "Mon,Tue,Thu", 12, "https://img.freepik.com/free-photo/close-up-health-worker_23-2149112576.jpg?t=st=1769968157~exp=1769971757~hmac=cef906f5b4c3c4931da10ccbb42c3abb3f1dbff106c2d5b7b947cd2fc315c042", "Pawly Main Clinic", "Dr. James Sterling", 4.7999999999999998, "Dental & Oral Surgery" },
                    { 4, "Wed,Sat,Sun", 9, "https://img.freepik.com/free-photo/portrait-beautiful-young-female-doctor_329181-1163.jpg?t=st=1769968709~exp=1769972309~hmac=f14363b73f0cfa29201dfd812bb25548db7a9596a4630cccf38494b50bd498cf&w=1480", "Pawly Main Clinic", "Dr. Elena Petrova", 4.9000000000000004, "Exotic Animal Specialist" }
                });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 2, 46, 21, 945, DateTimeKind.Utc).AddTicks(4260));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 1, 9, 38, 238, DateTimeKind.Utc).AddTicks(3439));
        }
    }
}
