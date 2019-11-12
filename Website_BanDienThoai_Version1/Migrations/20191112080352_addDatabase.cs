using Microsoft.EntityFrameworkCore.Migrations;

namespace Website_BanDienThoai_Version1.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Bill_Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Details_ProductId1",
                table: "Bill_Details",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Details_Products_ProductId1",
                table: "Bill_Details",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Details_Products_ProductId1",
                table: "Bill_Details");

            migrationBuilder.DropIndex(
                name: "IX_Bill_Details_ProductId1",
                table: "Bill_Details");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Bill_Details");
        }
    }
}
