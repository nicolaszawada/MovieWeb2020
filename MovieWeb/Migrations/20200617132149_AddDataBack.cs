using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieWeb.Migrations
{
    public partial class AddDataBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WatchStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nog niet gezien" },
                    { 2, "Al gezien" },
                    { 3, "Nooit meer zien!!!" },
                    { 4, "Nog eens opnieuw zien" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WatchStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WatchStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WatchStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WatchStatuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
