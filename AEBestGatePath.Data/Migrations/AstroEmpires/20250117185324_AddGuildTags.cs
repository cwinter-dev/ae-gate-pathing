using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEBestGatePath.Data.Migrations.AstroEmpires
{
    /// <inheritdoc />
    public partial class AddGuildTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Guilds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Guilds",
                keyColumn: "Id",
                keyValue: new Guid("17f9eba5-63bf-4ad0-9415-70b6e482fd7a"),
                column: "Tag",
                value: "CRUEL");

            migrationBuilder.UpdateData(
                table: "Guilds",
                keyColumn: "Id",
                keyValue: new Guid("b70b6921-9ee7-4cba-914f-c4bc619dc4b2"),
                column: "Tag",
                value: "QUAD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Guilds");
        }
    }
}
