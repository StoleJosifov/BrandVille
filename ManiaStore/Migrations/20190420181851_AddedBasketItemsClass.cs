using Microsoft.EntityFrameworkCore.Migrations;

namespace BrandVille.Migrations
{
    public partial class AddedBasketItemsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModelView");

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    BrandVilleUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_BasketItems_AspNetUsers_BrandVilleUserId",
                        column: x => x.BrandVilleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BrandVilleUserId",
                table: "BasketItems",
                column: "BrandVilleUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.CreateTable(
                name: "ProductModelView",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    BackPictureSrc = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    BrandVilleUserId = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true),
                    DiscountLimit = table.Column<string>(nullable: true),
                    FrontPictureSrc = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Season = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    StartingPrice = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelView", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductModelView_AspNetUsers_BrandVilleUserId",
                        column: x => x.BrandVilleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelView_BrandVilleUserId",
                table: "ProductModelView",
                column: "BrandVilleUserId");
        }
    }
}
