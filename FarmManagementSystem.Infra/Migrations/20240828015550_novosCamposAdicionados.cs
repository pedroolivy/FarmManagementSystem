using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagementSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class novosCamposAdicionados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdd",
                table: "Farm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FarmIsActive",
                table: "Farm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdd",
                table: "Crop",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdd",
                table: "Farm");

            migrationBuilder.DropColumn(
                name: "FarmIsActive",
                table: "Farm");

            migrationBuilder.DropColumn(
                name: "DateAdd",
                table: "Crop");
        }
    }
}
