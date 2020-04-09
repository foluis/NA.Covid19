using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NA.Covid19.Data.Migrations
{
    public partial class AddReportsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalReports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Confirmed = table.Column<long>(nullable: false),
                    Deaths = table.Column<long>(nullable: false),
                    Recovered = table.Column<long>(nullable: false),
                    Active = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalReports");
        }
    }
}
