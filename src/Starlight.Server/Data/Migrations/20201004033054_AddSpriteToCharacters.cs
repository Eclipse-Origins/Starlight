using Microsoft.EntityFrameworkCore.Migrations;

namespace Starlight.Server.Data.Migrations
{
    public partial class AddSpriteToCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sprite",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sprite",
                table: "Characters");
        }
    }
}
