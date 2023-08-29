using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunder_Mifflin_Paper_Company.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartProductID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductOrder_CartProduct_ProductsProductID_ProductsCustomerUserName",
                table: "CartProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductOrder",
                table: "CartProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_CartProductOrder_ProductsProductID_ProductsCustomerUserName",
                table: "CartProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "ProductsCustomerUserName",
                table: "CartProductOrder");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "CartProductOrder",
                newName: "ProductsCartProductID");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerUserName",
                table: "CartProduct",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CartProductID",
                table: "CartProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductOrder",
                table: "CartProductOrder",
                columns: new[] { "OrdersOrderID", "ProductsCartProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                column: "CartProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartProductOrder_ProductsCartProductID",
                table: "CartProductOrder",
                column: "ProductsCartProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductID",
                table: "CartProduct",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductOrder_CartProduct_ProductsCartProductID",
                table: "CartProductOrder",
                column: "ProductsCartProductID",
                principalTable: "CartProduct",
                principalColumn: "CartProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProductOrder_CartProduct_ProductsCartProductID",
                table: "CartProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProductOrder",
                table: "CartProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_CartProductOrder_ProductsCartProductID",
                table: "CartProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_ProductID",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "CartProductID",
                table: "CartProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsCartProductID",
                table: "CartProductOrder",
                newName: "ProductsProductID");

            migrationBuilder.AddColumn<string>(
                name: "ProductsCustomerUserName",
                table: "CartProductOrder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerUserName",
                table: "CartProduct",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProductOrder",
                table: "CartProductOrder",
                columns: new[] { "OrdersOrderID", "ProductsProductID", "ProductsCustomerUserName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                columns: new[] { "ProductID", "CustomerUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_CartProductOrder_ProductsProductID_ProductsCustomerUserName",
                table: "CartProductOrder",
                columns: new[] { "ProductsProductID", "ProductsCustomerUserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProductOrder_CartProduct_ProductsProductID_ProductsCustomerUserName",
                table: "CartProductOrder",
                columns: new[] { "ProductsProductID", "ProductsCustomerUserName" },
                principalTable: "CartProduct",
                principalColumns: new[] { "ProductID", "CustomerUserName" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
