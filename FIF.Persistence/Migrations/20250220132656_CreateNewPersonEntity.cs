using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIF.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewPersonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Persons",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MealPreferences",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonalIdentificationNumber",
                table: "Persons",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Religion",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TShrtSize",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MealPreferences",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonalIdentificationNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TShrtSize",
                table: "Persons");
        }
    }
}
