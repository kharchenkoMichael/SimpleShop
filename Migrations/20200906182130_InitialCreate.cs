using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    NumberOfItemsInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category1" },
                    { 2, "Category2" },
                    { 3, "Category3" },
                    { 4, "Category4" },
                    { 5, "Category5" },
                    { 6, "Category6" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NumberOfItemsInStock", "Price", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1, "Product1", 100, 100.0, 1 },
                    { 27, "Product27", 100, 100.0, 6 },
                    { 26, "Product26", 100, 100.0, 5 },
                    { 25, "Product25", 100, 100.0, 5 },
                    { 24, "Product24", 100, 100.0, 5 },
                    { 23, "Product23", 100, 100.0, 5 },
                    { 22, "Product22", 100, 100.0, 4 },
                    { 21, "Product21", 100, 100.0, 4 },
                    { 20, "Product20", 100, 100.0, 4 },
                    { 19, "Product19", 100, 100.0, 3 },
                    { 18, "Product18", 100, 100.0, 3 },
                    { 17, "Product17", 100, 100.0, 3 },
                    { 16, "Product16", 100, 100.0, 2 },
                    { 28, "Product28", 100, 100.0, 6 },
                    { 15, "Product15", 100, 100.0, 2 },
                    { 13, "Product13", 100, 100.0, 2 },
                    { 12, "Product12", 100, 100.0, 1 },
                    { 11, "Product11", 100, 100.0, 1 },
                    { 10, "Product10", 100, 100.0, 1 },
                    { 9, "Product9", 100, 100.0, 1 },
                    { 8, "Product8", 100, 100.0, 1 },
                    { 7, "Product7", 100, 100.0, 1 },
                    { 6, "Product6", 100, 100.0, 1 },
                    { 5, "Product5", 100, 100.0, 1 },
                    { 4, "Product4", 100, 100.0, 1 },
                    { 3, "Product3", 100, 100.0, 1 },
                    { 2, "Product2", 100, 100.0, 1 },
                    { 14, "Product14", 100, 100.0, 2 },
                    { 29, "Product29", 100, 100.0, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
