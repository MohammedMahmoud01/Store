using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ItemDiscountRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TbItemDiscount_ItemId",
                table: "TbItemDiscount",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItemDiscount_TbItem_ItemId",
                table: "TbItemDiscount",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItemDiscount_TbItem_ItemId",
                table: "TbItemDiscount");

            migrationBuilder.DropIndex(
                name: "IX_TbItemDiscount_ItemId",
                table: "TbItemDiscount");
        }
    }
}
