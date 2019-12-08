using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class rideId_to_ticketv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_RideToRouteId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "RideToRouteId",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RideToRouteId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RideToRouteId",
                table: "Ticket",
                column: "RideToRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket",
                column: "RideToRouteId",
                principalTable: "RideToRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
