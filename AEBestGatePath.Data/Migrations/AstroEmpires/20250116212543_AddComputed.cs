using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AEBestGatePath.Data.Migrations.AstroEmpires
{
    /// <inheritdoc />
    public partial class AddComputed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SeedData");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SeedData",
                type: "uuid",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Gates",
                type: "integer",
                nullable: false,
                computedColumnSql: "\"Location_RingPosition\" + \"Location_Ring\" * 10 + \"Location_SystemX\" * 10^2 + \"Location_SystemY\" * 10^3 + \"Location_RegionX\" * 10^4 + \"Location_RegionY\" * 10^5 + \"Location_Galaxy\" * 10^6 + \"Location_Cluster\" * 10^7",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Gates");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SeedData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
