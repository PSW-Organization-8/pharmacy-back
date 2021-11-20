using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyAPI.Migrations
{
    public partial class response : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objection",
                table: "Objection");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Responses");

            migrationBuilder.RenameTable(
                name: "Objection",
                newName: "Objections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objections",
                table: "Objections",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Objections",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HopsitalName", "TextObjection" },
                values: new object[] { "Bolnica1", "Ne valja nista" });

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HospitalName", "TextResponse" },
                values: new object[] { "Bolnica1", "Kleveta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Objections",
                table: "Objections");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Response");

            migrationBuilder.RenameTable(
                name: "Objections",
                newName: "Objection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objection",
                table: "Objection",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Objection",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HopsitalName", "TextObjection" },
                values: new object[] { "Ne valja nista", "Bolnica1" });

            migrationBuilder.UpdateData(
                table: "Response",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HospitalName", "TextResponse" },
                values: new object[] { "Kleveta", "Bolnica1" });
        }
    }
}
