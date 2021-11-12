using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class medication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Usage = table.Column<string>(type: "text", nullable: true),
                    Precautions = table.Column<string>(type: "text", nullable: true),
                    PotntialDangers = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationIngredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationIngredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectionIdFromHospitalDatabase = table.Column<long>(type: "bigint", nullable: false),
                    HopsitalName = table.Column<string>(type: "text", nullable: true),
                    TextObjection = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    AdressNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistratedHospitals",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistratedHospitals", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjectionIdFromHospitalDatabase = table.Column<long>(type: "bigint", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    TextResponse = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationMedicationIngredient",
                columns: table => new
                {
                    MedicationIngredientsId = table.Column<long>(type: "bigint", nullable: false),
                    MedicationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationMedicationIngredient", x => new { x.MedicationIngredientsId, x.MedicationsId });
                    table.ForeignKey(
                        name: "FK_MedicationMedicationIngredient_Medication_MedicationsId",
                        column: x => x.MedicationsId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationMedicationIngredient_MedicationIngredient_Medicat~",
                        column: x => x.MedicationIngredientsId,
                        principalTable: "MedicationIngredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medication",
                columns: new[] { "Id", "Manufacturer", "Name", "PotntialDangers", "Precautions", "Quantity", "Status", "Usage" },
                values: new object[,]
                {
                    { 1L, "J&J", "Synthroid", "None.", "None.", 150, 0, "Taken once per day" },
                    { 2L, "Merck & Co. Inc.", "Ventolin", "Not advised for pregnant women.", "None.", 200, 2, "Taken twice per day" },
                    { 3L, "Pfizer Inc.", "Januvia", "Not advised for children.", "None.", 750, 0, "Taken once once every 5 hours" }
                });

            migrationBuilder.InsertData(
                table: "MedicationIngredient",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Vitamin C" },
                    { 2L, "Phosphorus" },
                    { 3L, "Calcium" }
                });

            migrationBuilder.InsertData(
                table: "Objection",
                columns: new[] { "Id", "HopsitalName", "ObjectionIdFromHospitalDatabase", "TextObjection" },
                values: new object[] { 1L, "Ne valja nista", 0L, "Bolnica1" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Adress", "AdressNumber", "City", "Name" },
                values: new object[,]
                {
                    { 1L, "Rumenačka", "15", "Novi Sad", "Janković" },
                    { 2L, "Bulevar oslobođenja", "135", "Novi Sad", "Janković" },
                    { 3L, "Olge Jovanović", "18a", "Beograd", "Janković" }
                });

            migrationBuilder.InsertData(
                table: "RegistratedHospitals",
                columns: new[] { "Name", "ApiKey", "Url" },
                values: new object[] { "Bolnica1", "fds15d4fs6", "http:localhost:7313" });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "Id", "HospitalName", "ObjectionIdFromHospitalDatabase", "TextResponse" },
                values: new object[] { 1L, "Kleveta", 0L, "Bolnica1" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationMedicationIngredient_MedicationsId",
                table: "MedicationMedicationIngredient",
                column: "MedicationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationMedicationIngredient");

            migrationBuilder.DropTable(
                name: "Objection");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "RegistratedHospitals");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "MedicationIngredient");
        }
    }
}
