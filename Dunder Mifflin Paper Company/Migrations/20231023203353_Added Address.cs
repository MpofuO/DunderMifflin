using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunder_Mifflin_Paper_Company.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Product_ProductID",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "Favourite");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_ProductID",
                table: "Favourite",
                newName: "IX_Favourite_ProductID");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethod",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourite",
                table: "Favourite",
                column: "FavouriteID");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressID",
                table: "Order",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_Product_ProductID",
                table: "Favourite",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_Product_ProductID",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Order_AddressID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourite",
                table: "Favourite");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Favourite",
                newName: "Favourites");

            migrationBuilder.RenameIndex(
                name: "IX_Favourite_ProductID",
                table: "Favourites",
                newName: "IX_Favourites_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "FavouriteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Product_ProductID",
                table: "Favourites",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
