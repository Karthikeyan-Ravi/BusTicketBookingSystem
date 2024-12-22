using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatNumberToSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Routes_RouteId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_RouteId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RouteId",
                table: "Seats",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Routes_RouteId",
                table: "Seats",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
