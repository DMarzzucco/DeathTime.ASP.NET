using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeathTime.ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class UNiqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserModel_Email",
                table: "UserModel",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_Name",
                table: "UserModel",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserModel_Email",
                table: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_UserModel_Name",
                table: "UserModel");
        }
    }
}
