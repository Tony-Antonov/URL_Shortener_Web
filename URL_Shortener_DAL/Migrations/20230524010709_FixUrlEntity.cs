using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URL_Shortener_DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixUrlEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrl_AspNetUsers_CreatedById",
                table: "ShortUrl");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrl_CreatedById",
                table: "ShortUrl");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ShortUrl");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrl_UserId",
                table: "ShortUrl",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrl_AspNetUsers_UserId",
                table: "ShortUrl",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrl_AspNetUsers_UserId",
                table: "ShortUrl");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrl_UserId",
                table: "ShortUrl");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ShortUrl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrl_CreatedById",
                table: "ShortUrl",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrl_AspNetUsers_CreatedById",
                table: "ShortUrl",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
