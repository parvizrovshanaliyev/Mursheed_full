using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class someTables_added_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Country_CountryId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CountryId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateFromTo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateFromTo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutePlace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromRoutePlaceId = table.Column<int>(nullable: false),
                    ToRoutePlaceId = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_RoutePlace_FromRoutePlaceId",
                        column: x => x.FromRoutePlaceId,
                        principalTable: "RoutePlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Route_RoutePlace_ToRoutePlaceId",
                        column: x => x.ToRoutePlaceId,
                        principalTable: "RoutePlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transporter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transporter_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristId = table.Column<int>(nullable: false),
                    TransporterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_Tourist_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ride_Transporter_TransporterId",
                        column: x => x.TransporterId,
                        principalTable: "Transporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransporterRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristId = table.Column<int>(nullable: false),
                    TransporterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransporterRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransporterRating_Tourist_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransporterRating_Transporter_TransporterId",
                        column: x => x.TransporterId,
                        principalTable: "Transporter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RideToRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    DateFromToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideToRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RideToRoute_DateFromTo_DateFromToId",
                        column: x => x.DateFromToId,
                        principalTable: "DateFromTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideToRoute_Ride_RideId",
                        column: x => x.RideId,
                        principalTable: "Ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideToRoute_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideToRouteId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_RideToRoute_RideToRouteId",
                        column: x => x.RideToRouteId,
                        principalTable: "RideToRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                table: "Model",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_TouristId",
                table: "Ride",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_TransporterId",
                table: "Ride",
                column: "TransporterId");

            migrationBuilder.CreateIndex(
                name: "IX_RideToRoute_DateFromToId",
                table: "RideToRoute",
                column: "DateFromToId");

            migrationBuilder.CreateIndex(
                name: "IX_RideToRoute_RideId",
                table: "RideToRoute",
                column: "RideId");

            migrationBuilder.CreateIndex(
                name: "IX_RideToRoute_RouteId",
                table: "RideToRoute",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_FromRoutePlaceId",
                table: "Route",
                column: "FromRoutePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ToRoutePlaceId",
                table: "Route",
                column: "ToRoutePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RideToRouteId",
                table: "Ticket",
                column: "RideToRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transporter_CarId",
                table: "Transporter",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TransporterRating_TouristId",
                table: "TransporterRating",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_TransporterRating_TransporterId",
                table: "TransporterRating",
                column: "TransporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TransporterRating");

            migrationBuilder.DropTable(
                name: "RideToRoute");

            migrationBuilder.DropTable(
                name: "DateFromTo");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Tourist");

            migrationBuilder.DropTable(
                name: "Transporter");

            migrationBuilder.DropTable(
                name: "RoutePlace");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountryId",
                table: "Person",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Country_CountryId",
                table: "Person",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
