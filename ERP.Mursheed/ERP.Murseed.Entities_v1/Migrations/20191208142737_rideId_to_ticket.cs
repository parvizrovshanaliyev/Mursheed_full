using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class rideId_to_ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "RideToRouteId",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RideId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RideId",
                table: "Ticket",
                column: "RideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Ride_RideId",
                table: "Ticket",
                column: "RideId",
                principalTable: "Ride",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket",
                column: "RideToRouteId",
                principalTable: "RideToRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Ride_RideId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_RideId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "RideToRouteId",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_RideToRoute_RideToRouteId",
                table: "Ticket",
                column: "RideToRouteId",
                principalTable: "RideToRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
