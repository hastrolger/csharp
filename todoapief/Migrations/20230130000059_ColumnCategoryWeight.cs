﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapief.Migrations
{
    /// <inheritdoc />
    public partial class ColumnCategoryWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Category");
        }
    }
}
