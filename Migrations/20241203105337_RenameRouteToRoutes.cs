using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicketBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameRouteToRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_Buses_BusId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Buses_BusId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Route_RouteId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Route",
                table: "Route");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "Route",
                newName: "Routes");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_RouteId",
                table: "Seats",
                newName: "IX_Seats_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_BusId",
                table: "Seats",
                newName: "IX_Seats_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_BusId",
                table: "Routes",
                newName: "IX_Routes_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Buses_BusId",
                table: "Seats",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Routes_RouteId",
                table: "Seats",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Buses_BusId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Buses_BusId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Routes_RouteId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "Route");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_RouteId",
                table: "Seat",
                newName: "IX_Seat_RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_BusId",
                table: "Seat",
                newName: "IX_Seat_BusId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_BusId",
                table: "Route",
                newName: "IX_Route_BusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Route",
                table: "Route",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Buses_BusId",
                table: "Route",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Buses_BusId",
                table: "Seat",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Route_RouteId",
                table: "Seat",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id");
        }
    }
}
