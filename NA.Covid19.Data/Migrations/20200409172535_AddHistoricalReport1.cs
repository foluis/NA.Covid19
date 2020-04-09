using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NA.Covid19.Data.Migrations
{
    public partial class AddHistoricalReport1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Confirmed = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    Recovered = table.Column<int>(nullable: false),
                    Active = table.Column<int>(nullable: false)
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
