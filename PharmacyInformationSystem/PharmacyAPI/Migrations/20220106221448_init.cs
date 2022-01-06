using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientInMedication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationID = table.Column<long>(type: "bigint", nullable: false),
                    IngredientID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientInMedication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PharmacyID = table.Column<long>(type: "bigint", nullable: false),
                    MedicationID = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationPromotion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PromotionPeriod_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PromotionPeriod_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPromotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
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
                    PotentialDangers = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    ContentNotification = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objections",
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
                    table.PrimaryKey("PK_Objections", x => x.Id);
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
                name: "PharmacyOffers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PharmacyId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    TenderIdInHospital = table.Column<long>(type: "bigint", nullable: false),
                    PharmacyName = table.Column<string>(type: "text", nullable: true),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    TimePosted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOffers", x => x.Id);
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
                name: "Responses",
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
                    table.PrimaryKey("PK_Responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    IdInHospital = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationIngredients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MedicationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationIngredients_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationMedicationPromotion",
                columns: table => new
                {
                    PromotedMedicationsId = table.Column<long>(type: "bigint", nullable: false),
                    medicationPromotionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationMedicationPromotion", x => new { x.PromotedMedicationsId, x.medicationPromotionsId });
                    table.ForeignKey(
                        name: "FK_MedicationMedicationPromotion_MedicationPromotion_medicatio~",
                        column: x => x.medicationPromotionsId,
                        principalTable: "MedicationPromotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationMedicationPromotion_Medications_PromotedMedicatio~",
                        column: x => x.PromotedMedicationsId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyOfferComponents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationId = table.Column<long>(type: "bigint", nullable: false),
                    MedicationName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PharmacyOfferId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyOfferComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmacyOfferComponents_PharmacyOffers_PharmacyOfferId",
                        column: x => x.PharmacyOfferId,
                        principalTable: "PharmacyOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderMedications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationName = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderMedications_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IngredientInMedication",
                columns: new[] { "Id", "IngredientID", "MedicationID" },
                values: new object[,]
                {
                    { 3L, 2L, 1L },
                    { 2L, 2L, 2L },
                    { 1L, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "InventoryLogs",
                columns: new[] { "Id", "MedicationID", "PharmacyID", "Quantity" },
                values: new object[,]
                {
                    { 2L, 2L, 1L, 85L },
                    { 3L, 1L, 2L, 20L },
                    { 4L, 3L, 2L, 120L },
                    { 1L, 1L, 1L, 65L },
                    { 5L, 1L, 3L, 14L }
                });

            migrationBuilder.InsertData(
                table: "MedicationIngredients",
                columns: new[] { "Id", "MedicationId", "Name" },
                values: new object[,]
                {
                    { 1L, null, "Vitamin C" },
                    { 2L, null, "Phosphorus" },
                    { 3L, null, "Calcium" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Manufacturer", "Name", "PotentialDangers", "Precautions", "Quantity", "Status", "Usage" },
                values: new object[,]
                {
                    { 1L, "J&J", "Synthroid", "None.", "None.", 150, 0, "Taken once per day" },
                    { 3L, "Pfizer Inc.", "Januvia", "Not advised for children.", "None.", 750, 0, "Taken once once every 5 hours" },
                    { 2L, "Merck & Co. Inc.", "Ventolin", "Not advised for pregnant women.", "None.", 200, 2, "Taken twice per day" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "ContentNotification", "FileName", "Read", "Title" },
                values: new object[] { 1L, "Ovde ce da bude tekst nekog izvestaja", "MedicationSpecifiation.pdf", true, "Izvestaj" });

            migrationBuilder.InsertData(
                table: "Objections",
                columns: new[] { "Id", "HopsitalName", "ObjectionIdFromHospitalDatabase", "TextObjection" },
                values: new object[] { 1L, "Bolnica1", 0L, "Ne valja nista" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "Adress", "AdressNumber", "City", "Name" },
                values: new object[,]
                {
                    { 1L, "Rumenačka", "15", "Novi Sad", "Janković" },
                    { 3L, "Olge Jovanović", "18a", "Beograd", "Janković" },
                    { 2L, "Bulevar oslobođenja", "135", "Novi Sad", "Janković" }
                });

            migrationBuilder.InsertData(
                table: "PharmacyOffers",
                columns: new[] { "Id", "HospitalName", "PharmacyId", "PharmacyName", "TenderId", "TenderIdInHospital", "TimePosted" },
                values: new object[,]
                {
                    { 2L, null, 0L, "Apoteka1", 0L, 0L, new DateTime(2021, 10, 12, 9, 28, 13, 0, DateTimeKind.Unspecified) },
                    { 1L, null, 0L, "Apoteka1", 0L, 0L, new DateTime(2021, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RegistratedHospitals",
                columns: new[] { "Name", "ApiKey", "Url" },
                values: new object[] { "Bolnica1", "fds15d4fs6", "http:localhost:7313" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "HospitalName", "ObjectionIdFromHospitalDatabase", "TextResponse" },
                values: new object[] { 1L, "Bolnica1", 0L, "Kleveta" });

            migrationBuilder.InsertData(
                table: "Tenders",
                columns: new[] { "Id", "EndDate", "HospitalName", "IdInHospital", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 2, 25, 23, 14, 45, 837, DateTimeKind.Local).AddTicks(3034), "Bolnica1", 0L, "Tender za Bolnicu zdravo", new DateTime(2022, 1, 6, 23, 14, 45, 823, DateTimeKind.Local).AddTicks(7025) },
                    { 2L, new DateTime(2022, 2, 5, 23, 14, 45, 838, DateTimeKind.Local).AddTicks(5384), "Bolnica1", 0L, "Tender za neku drugu Bolnicu", new DateTime(2022, 1, 6, 23, 14, 45, 838, DateTimeKind.Local).AddTicks(5263) }
                });

            migrationBuilder.InsertData(
                table: "PharmacyOfferComponents",
                columns: new[] { "Id", "MedicationId", "MedicationName", "PharmacyOfferId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, null, 1L, 100.0, 10L },
                    { 2L, 2L, null, 1L, 1000.0, 150L },
                    { 3L, 3L, null, 1L, 2000.0, 150L },
                    { 4L, 2L, null, 2L, 1000.0, 15L },
                    { 5L, 3L, null, 2L, 2000.0, 2L }
                });

            migrationBuilder.InsertData(
                table: "TenderMedications",
                columns: new[] { "Id", "MedicationName", "Quantity", "TenderId" },
                values: new object[,]
                {
                    { 1L, "Paracetamol", 10, 1L },
                    { 2L, "Vitamin C", 10, 1L },
                    { 4L, "Zavoj", 100, 1L },
                    { 3L, "Longacef", 100, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationIngredients_MedicationId",
                table: "MedicationIngredients",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationMedicationPromotion_medicationPromotionsId",
                table: "MedicationMedicationPromotion",
                column: "medicationPromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyOfferComponents_PharmacyOfferId",
                table: "PharmacyOfferComponents",
                column: "PharmacyOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderMedications_TenderId",
                table: "TenderMedications",
                column: "TenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientInMedication");

            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "MedicationIngredients");

            migrationBuilder.DropTable(
                name: "MedicationMedicationPromotion");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Objections");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyOfferComponents");

            migrationBuilder.DropTable(
                name: "RegistratedHospitals");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "TenderMedications");

            migrationBuilder.DropTable(
                name: "MedicationPromotion");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "PharmacyOffers");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
