using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestowyKolos.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_IdClient",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Order",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdClient",
                table: "Order",
                newName: "IX_Order_StatusID");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Product_Order",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Ammount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Order", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_Product_Order_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Order_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Order_OrderID",
                table: "Product_Order",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_StatusID",
                table: "Order",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_StatusID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Product_Order");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ClientID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Order",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Order_StatusID",
                table: "Order",
                newName: "IX_Order_IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_IdClient",
                table: "Order",
                column: "IdClient",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
