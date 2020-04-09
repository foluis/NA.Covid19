using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NA.Covid19.Data.Migrations
{
    public partial class removeReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalReports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<long>(type: "bigint", nullable: false),
                    Confirmed = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Deaths = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recovered = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalReports", x => x.Id);
                });
        }
    }
}
