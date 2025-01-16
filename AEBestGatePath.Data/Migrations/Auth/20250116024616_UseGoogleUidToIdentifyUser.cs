using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEBestGatePath.Data.Migrations.Auth
{
    /// <inheritdoc />
    public partial class UseGoogleUidToIdentifyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                schema: "auth",
                table: "User",
                newName: "GoogleUid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoogleUid",
                schema: "auth",
                table: "User",
                newName: "EmailAddress");
        }
    }
}
