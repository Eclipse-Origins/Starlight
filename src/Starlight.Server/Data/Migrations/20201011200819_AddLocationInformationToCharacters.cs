using Microsoft.EntityFrameworkCore.Migrations;

namespace Starlight.Server.Data.Migrations
{
    public partial class AddLocationInformationToCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Characters");
        }
    }
}
