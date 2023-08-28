using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunder_Mifflin_Paper_Company.Migrations
{
    /// <inheritdoc />
    public partial class AddedisOrderedToCartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isOrdered",
                table: "CartProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isOrdered",
                table: "CartProduct");
        }
    }
}
