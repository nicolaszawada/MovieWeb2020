using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWeb.Migrations
{
    public partial class AddWatchStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WatchStatusId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WatchStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WatchStatusId",
                table: "Movies",
                column: "WatchStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_WatchStatuses_WatchStatusId",
                table: "Movies",
                column: "WatchStatusId",
                principalTable: "WatchStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_WatchStatuses_WatchStatusId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "WatchStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Movies_WatchStatusId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "WatchStatusId",
                table: "Movies");
        }
    }
}
