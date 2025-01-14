using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AEBestGatePath.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeedData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GuildId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Occupied = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuildId = table.Column<Guid>(type: "uuid", nullable: true),
                    Location_Cluster = table.Column<int>(type: "integer", nullable: false),
                    Location_Galaxy = table.Column<int>(type: "integer", nullable: false),
                    Location_GateLevel = table.Column<int>(type: "integer", nullable: false),
                    Location_LogiCommander = table.Column<int>(type: "integer", nullable: false),
                    Location_RegionX = table.Column<int>(type: "integer", nullable: false),
                    Location_RegionY = table.Column<int>(type: "integer", nullable: false),
                    Location_Ring = table.Column<int>(type: "integer", nullable: false),
                    Location_RingPosition = table.Column<int>(type: "integer", nullable: false),
                    Location_Server = table.Column<char>(type: "character(1)", nullable: false),
                    Location_SystemX = table.Column<int>(type: "integer", nullable: false),
                    Location_SystemY = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gates_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gates_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guilds",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("17f9eba5-63bf-4ad0-9415-70b6e482fd7a"), 6469, "CRUEL" },
                    { new Guid("b70b6921-9ee7-4cba-914f-c4bc619dc4b2"), 12530, "actually four guilds" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gates_GuildId",
                table: "Gates",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_PlayerId",
                table: "Gates",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Guilds_Name",
                table: "Guilds",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GuildId",
                table: "Players",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeedData_Name",
                table: "SeedData",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "SeedData");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Guilds");
        }
    }
}
