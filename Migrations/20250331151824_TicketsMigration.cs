using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAD_WorkAndTravel.Migrations
{
    /// <inheritdoc />
    public partial class TicketsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ArrDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
