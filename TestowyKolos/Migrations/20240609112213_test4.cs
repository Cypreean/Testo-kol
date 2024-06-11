using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestowyKolos.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { 1, "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[] { 1, "Test", 10m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "IdStatus", "Name" },
                values: new object[] { 1, "Nowe" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "ID", "ClientID", "CreatedAt", "DateFinished", "StatusID" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 9, 13, 22, 12, 884, DateTimeKind.Local).AddTicks(4370), new DateTime(2024, 6, 9, 13, 22, 12, 884, DateTimeKind.Local).AddTicks(4410), 1 });

            migrationBuilder.InsertData(
                table: "Product_Order",
                columns: new[] { "OrderID", "ProductID", "Ammount" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product_Order",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 1);
        }
    }
}
