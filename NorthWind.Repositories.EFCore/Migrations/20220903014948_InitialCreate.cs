using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthWind.Repositories.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyProperty",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ShipCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ShipCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ShipPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    ShippingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_MyProperty_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Customers_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
