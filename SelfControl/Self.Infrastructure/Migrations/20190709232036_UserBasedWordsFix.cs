using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Self.Infrastructure.Migrations
{
    public partial class UserBasedWordsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_Baskets_BasketId",
                table: "Word");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Word_BasketId",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Word");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Word",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Word");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Word",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Word_BasketId",
                table: "Word",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Baskets_BasketId",
                table: "Word",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
