using Microsoft.EntityFrameworkCore.Migrations;

namespace Self.Infrastructure.Migrations
{
    public partial class UserBasedWordBasketsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Word",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_Baskets_BasketId",
                table: "Word");

            migrationBuilder.DropIndex(
                name: "IX_Word_BasketId",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Word");
        }
    }
}
