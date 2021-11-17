using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
{
    public partial class inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLog",
                table: "InventoryLog");

            migrationBuilder.RenameTable(
                name: "InventoryLog",
                newName: "InventoryLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs");

            migrationBuilder.RenameTable(
                name: "InventoryLogs",
                newName: "InventoryLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLog",
                table: "InventoryLog",
                column: "Id");
        }
    }
}
