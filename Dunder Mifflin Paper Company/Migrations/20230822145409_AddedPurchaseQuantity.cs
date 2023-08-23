using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunder_Mifflin_Paper_Company.Migrations
{
    /// <inheritdoc />
    public partial class AddedPurchaseQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "CartProductOrder",
                columns: table => new
                {
                    OrdersOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false),
                    ProductsCustomerUserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProductOrder", x => new { x.OrdersOrderID, x.ProductsProductID, x.ProductsCustomerUserName });
                    table.ForeignKey(
                        name: "FK_CartProductOrder_CartProduct_ProductsProductID_ProductsCustomerUserName",
                        columns: x => new { x.ProductsProductID, x.ProductsCustomerUserName },
                        principalTable: "CartProduct",
                        principalColumns: new[] { "ProductID", "CustomerUserName" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProductOrder_Order_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductOrder_ProductsProductID_ProductsCustomerUserName",
                table: "CartProductOrder",
                columns: new[] { "ProductsProductID", "ProductsCustomerUserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProductOrder");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrderID, x.ProductsProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductID",
                table: "OrderProduct",
                column: "ProductsProductID");
        }
    }
}
