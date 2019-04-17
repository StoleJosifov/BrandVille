using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrandVille.Migrations
{
    public partial class AddedBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailedPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Full = table.Column<string>(nullable: true),
                    Bill = table.Column<string>(nullable: true),
                    Coins = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    FullString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Src = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentPriceId = table.Column<int>(nullable: true),
                    SellMaxId = table.Column<int>(nullable: true),
                    SellMinId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceRange_DetailedPrice_CurrentPriceId",
                        column: x => x.CurrentPriceId,
                        principalTable: "DetailedPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceRange_DetailedPrice_SellMaxId",
                        column: x => x.SellMaxId,
                        principalTable: "DetailedPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceRange_DetailedPrice_SellMinId",
                        column: x => x.SellMinId,
                        principalTable: "DetailedPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FrontId = table.Column<int>(nullable: true),
                    BackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Picture_BackId",
                        column: x => x.BackId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_Picture_FrontId",
                        column: x => x.FrontId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    ManiaSize = table.Column<string>(nullable: true),
                    SizeLabel = table.Column<string>(nullable: true),
                    WithLabel = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ForAuction = table.Column<string>(nullable: true),
                    PicturesId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PriceRangeId = table.Column<int>(nullable: true),
                    IsMultiplePrice = table.Column<bool>(nullable: false),
                    FavouriteCounter = table.Column<string>(nullable: true),
                    ReservedUserId = table.Column<int>(nullable: false),
                    BrandVilleUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_BrandVilleUserId",
                        column: x => x.BrandVilleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Pictures_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_PriceRange_PriceRangeId",
                        column: x => x.PriceRangeId,
                        principalTable: "PriceRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    IsLastPrice = table.Column<bool>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_BackId",
                table: "Pictures",
                column: "BackId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_FrontId",
                table: "Pictures",
                column: "FrontId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceRange_CurrentPriceId",
                table: "PriceRange",
                column: "CurrentPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceRange_SellMaxId",
                table: "PriceRange",
                column: "SellMaxId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceRange_SellMinId",
                table: "PriceRange",
                column: "SellMinId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandVilleUserId",
                table: "Product",
                column: "BrandVilleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PicturesId",
                table: "Product",
                column: "PicturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PriceRangeId",
                table: "Product",
                column: "PriceRangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "PriceRange");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "DetailedPrice");
        }
    }
}
