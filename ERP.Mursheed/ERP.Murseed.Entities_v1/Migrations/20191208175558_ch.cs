using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class ch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RideToRoute_DateFromTo_DateFromToId",
                table: "RideToRoute");

            migrationBuilder.AddForeignKey(
                name: "FK_RideToRoute_DateFromTo_DateFromToId",
                table: "RideToRoute",
                column: "DateFromToId",
                principalTable: "DateFromTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RideToRoute_DateFromTo_DateFromToId",
                table: "RideToRoute");

            migrationBuilder.AddForeignKey(
                name: "FK_RideToRoute_DateFromTo_DateFromToId",
                table: "RideToRoute",
                column: "DateFromToId",
                principalTable: "DateFromTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
