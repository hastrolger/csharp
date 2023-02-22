using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todoapief.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName", "Weight" },
                values: new object[,]
                {
                    { new Guid("5c6a28dc-c167-4b7d-aa7b-0f37f7e67f97"), "Kind of job activities", "Job activities", 10 },
                    { new Guid("d78cfb1d-1f0a-4f55-bca5-0e78ea11252d"), "Kind if personal activities", "Personal activities", 15 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreatedAt", "TaskDescription", "TaskName", "TaskPriority" },
                values: new object[,]
                {
                    { new Guid("02c30a2d-3850-47e4-beb2-28a6d853ca39"), new Guid("d78cfb1d-1f0a-4f55-bca5-0e78ea11252d"), new DateTime(2023, 1, 29, 19, 30, 53, 271, DateTimeKind.Local).AddTicks(5980), "Do the dish before go the bed", "Do the dishes", 0 },
                    { new Guid("4be134e4-c867-481e-9410-21fdb296e7e9"), new Guid("5c6a28dc-c167-4b7d-aa7b-0f37f7e67f97"), new DateTime(2023, 1, 29, 19, 30, 53, 271, DateTimeKind.Local).AddTicks(6016), "Report of the monitoring service", "Prepare report of service", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("02c30a2d-3850-47e4-beb2-28a6d853ca39"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4be134e4-c867-481e-9410-21fdb296e7e9"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("5c6a28dc-c167-4b7d-aa7b-0f37f7e67f97"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d78cfb1d-1f0a-4f55-bca5-0e78ea11252d"));
        }
    }
}
