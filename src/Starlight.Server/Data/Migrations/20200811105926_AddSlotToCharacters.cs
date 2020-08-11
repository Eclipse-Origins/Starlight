using Microsoft.EntityFrameworkCore.Migrations;

namespace Starlight.Server.Data.Migrations
{
    public partial class AddSlotToCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Character",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Character");
        }
    }
}
