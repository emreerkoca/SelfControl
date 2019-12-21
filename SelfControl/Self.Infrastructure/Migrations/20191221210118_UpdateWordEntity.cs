using Microsoft.EntityFrameworkCore.Migrations;

namespace Self.Infrastructure.Migrations
{
    public partial class UpdateWordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sentence",
                table: "Word",
                maxLength: 140,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishMeaning",
                table: "Word",
                maxLength: 140,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishMeaning",
                table: "Word");

            migrationBuilder.AlterColumn<string>(
                name: "Sentence",
                table: "Word",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 140);
        }
    }
}
