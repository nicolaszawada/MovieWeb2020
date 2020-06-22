using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWeb.Migrations
{
    public partial class AddMovieAppUserFkTomOVIE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieAppUserId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieAppUserId",
                table: "Movies",
                column: "MovieAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_MovieAppUserId",
                table: "Movies",
                column: "MovieAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_MovieAppUserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieAppUserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieAppUserId",
                table: "Movies");
        }
    }
}
