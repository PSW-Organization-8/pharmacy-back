using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PharmacyAPI.Migrations.EventsDb
{
    public partial class eventsMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventApplicationName = table.Column<int>(type: "integer", nullable: false),
                    EventClass = table.Column<int>(type: "integer", nullable: false),
                    OptionalEventNumInfo = table.Column<double>(type: "double precision", nullable: false),
                    OptionalEventNumInfo2 = table.Column<double>(type: "double precision", nullable: false),
                    OptionalEventStrInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventApplicationName", "EventClass", "OptionalEventNumInfo", "OptionalEventNumInfo2", "OptionalEventStrInfo", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1L, 0, 1, 0.0, 0.0, null, new DateTime(2022, 1, 6, 16, 20, 40, 643, DateTimeKind.Local).AddTicks(1396), "username1" },
                    { 2L, 0, 2, 0.0, 0.0, null, new DateTime(2022, 1, 6, 16, 20, 40, 645, DateTimeKind.Local).AddTicks(2741), "username2" },
                    { 3L, 0, 0, 1.0, 0.0, null, new DateTime(2022, 1, 6, 16, 20, 40, 645, DateTimeKind.Local).AddTicks(2770), "username1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
