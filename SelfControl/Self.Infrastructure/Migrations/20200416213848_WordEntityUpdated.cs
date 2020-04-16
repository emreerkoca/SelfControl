using Microsoft.EntityFrameworkCore.Migrations;

namespace Self.Infrastructure.Migrations
{
    public partial class WordEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishMeaning",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "OriginalWord",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "TranslatedWord",
                table: "Word");

            migrationBuilder.AddColumn<string>(
                name: "Meaning",
                table: "Word",
                maxLength: 140,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vocable",
                table: "Word",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meaning",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Vocable",
                table: "Word");

            migrationBuilder.AddColumn<string>(
                name: "EnglishMeaning",
                table: "Word",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalWord",
                table: "Word",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TranslatedWord",
                table: "Word",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
