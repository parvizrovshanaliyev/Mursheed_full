using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BRAND",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISO = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NiceName = table.Column<string>(nullable: true),
                    ISO3 = table.Column<string>(nullable: true),
                    NumCode = table.Column<string>(nullable: true),
                    PhoneCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FROM_TO_DATE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FROM_TO_DATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MODEL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODEL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MODEL_BRAND_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BRAND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NiceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITY_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    GovernmentalId = table.Column<int>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PhotoName = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TOURIST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOURIST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOURIST_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TOURIST_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAR_MODEL_ModelId",
                        column: x => x.ModelId,
                        principalTable: "MODEL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROUTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCityId = table.Column<int>(nullable: false),
                    ToCityId = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Info = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROUTE_CITY_FromCityId",
                        column: x => x.FromCityId,
                        principalTable: "CITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROUTE_CITY_ToCityId",
                        column: x => x.ToCityId,
                        principalTable: "CITY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_LANGUAGE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_LANGUAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_LANGUAGE_GUIDE_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GUIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_LANGUAGE_LANGUAGE_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LANGUAGE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_RATING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristId = table.Column<int>(nullable: false),
                    GuideId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_RATING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_RATING_GUIDE_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GUIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_RATING_TOURIST_TouristId",
                        column: x => x.TouristId,
                        principalTable: "TOURIST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_RIDE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideId = table.Column<int>(nullable: false),
                    TouristId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_RIDE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_RIDE_GUIDE_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GUIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_RIDE_TOURIST_TouristId",
                        column: x => x.TouristId,
                        principalTable: "TOURIST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAR_PHOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    PhotoName = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_PHOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAR_PHOTO_CAR_CarId",
                        column: x => x.CarId,
                        principalTable: "CAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CustomId = table.Column<string>(nullable: true),
                    GovernmentalId = table.Column<int>(maxLength: 50, nullable: false),
                    DriverLicenseId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PhotoName = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_CAR_CarId",
                        column: x => x.CarId,
                        principalTable: "CAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_ROUTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_ROUTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_ROUTE_GUIDE_GuideId",
                        column: x => x.GuideId,
                        principalTable: "GUIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_ROUTE_ROUTE_RouteId",
                        column: x => x.RouteId,
                        principalTable: "ROUTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_RIDE_TO_ROUTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideRideId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    FromToDateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_RIDE_TO_ROUTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_RIDE_TO_ROUTE_FROM_TO_DATE_FromToDateId",
                        column: x => x.FromToDateId,
                        principalTable: "FROM_TO_DATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_RIDE_TO_ROUTE_GUIDE_RIDE_GuideRideId",
                        column: x => x.GuideRideId,
                        principalTable: "GUIDE_RIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GUIDE_RIDE_TO_ROUTE_ROUTE_RouteId",
                        column: x => x.RouteId,
                        principalTable: "ROUTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GUIDE_TICKET",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideRideId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUIDE_TICKET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GUIDE_TICKET_GUIDE_RIDE_GuideRideId",
                        column: x => x.GuideRideId,
                        principalTable: "GUIDE_RIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_LANGUAGE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_LANGUAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_LANGUAGE_DRIVER_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DRIVER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_LANGUAGE_LANGUAGE_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LANGUAGE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_RATING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_RATING", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_RATING_DRIVER_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DRIVER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_RATING_TOURIST_TouristId",
                        column: x => x.TouristId,
                        principalTable: "TOURIST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_RIDE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(nullable: false),
                    TouristId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_RIDE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_RIDE_DRIVER_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DRIVER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_RIDE_TOURIST_TouristId",
                        column: x => x.TouristId,
                        principalTable: "TOURIST",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_ROUTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_ROUTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_ROUTE_DRIVER_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DRIVER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_ROUTE_ROUTE_RouteId",
                        column: x => x.RouteId,
                        principalTable: "ROUTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_RIDE_TO_ROUTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverRideId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    FromToDateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_RIDE_TO_ROUTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_RIDE_TO_ROUTE_DRIVER_RIDE_DriverRideId",
                        column: x => x.DriverRideId,
                        principalTable: "DRIVER_RIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_RIDE_TO_ROUTE_FROM_TO_DATE_FromToDateId",
                        column: x => x.FromToDateId,
                        principalTable: "FROM_TO_DATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DRIVER_RIDE_TO_ROUTE_ROUTE_RouteId",
                        column: x => x.RouteId,
                        principalTable: "ROUTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DRIVER_TICKET",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverRideId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVER_TICKET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DRIVER_TICKET_DRIVER_RIDE_DriverRideId",
                        column: x => x.DriverRideId,
                        principalTable: "DRIVER_RIDE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_ModelId",
                table: "CAR",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_PHOTO_CarId",
                table: "CAR_PHOTO",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_CountryId",
                table: "CITY",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_ApplicationUserId",
                table: "DRIVER",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_CarId",
                table: "DRIVER",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_CountryId",
                table: "DRIVER",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_LANGUAGE_DriverId",
                table: "DRIVER_LANGUAGE",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_LANGUAGE_LanguageId",
                table: "DRIVER_LANGUAGE",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RATING_DriverId",
                table: "DRIVER_RATING",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RATING_TouristId",
                table: "DRIVER_RATING",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RIDE_DriverId",
                table: "DRIVER_RIDE",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RIDE_TouristId",
                table: "DRIVER_RIDE",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RIDE_TO_ROUTE_DriverRideId",
                table: "DRIVER_RIDE_TO_ROUTE",
                column: "DriverRideId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RIDE_TO_ROUTE_FromToDateId",
                table: "DRIVER_RIDE_TO_ROUTE",
                column: "FromToDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_RIDE_TO_ROUTE_RouteId",
                table: "DRIVER_RIDE_TO_ROUTE",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_ROUTE_DriverId",
                table: "DRIVER_ROUTE",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_ROUTE_RouteId",
                table: "DRIVER_ROUTE",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_DRIVER_TICKET_DriverRideId",
                table: "DRIVER_TICKET",
                column: "DriverRideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_ApplicationUserId",
                table: "GUIDE",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_CountryId",
                table: "GUIDE",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_LANGUAGE_GuideId",
                table: "GUIDE_LANGUAGE",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_LANGUAGE_LanguageId",
                table: "GUIDE_LANGUAGE",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RATING_GuideId",
                table: "GUIDE_RATING",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RATING_TouristId",
                table: "GUIDE_RATING",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RIDE_GuideId",
                table: "GUIDE_RIDE",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RIDE_TouristId",
                table: "GUIDE_RIDE",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RIDE_TO_ROUTE_FromToDateId",
                table: "GUIDE_RIDE_TO_ROUTE",
                column: "FromToDateId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RIDE_TO_ROUTE_GuideRideId",
                table: "GUIDE_RIDE_TO_ROUTE",
                column: "GuideRideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_RIDE_TO_ROUTE_RouteId",
                table: "GUIDE_RIDE_TO_ROUTE",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_ROUTE_GuideId",
                table: "GUIDE_ROUTE",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_ROUTE_RouteId",
                table: "GUIDE_ROUTE",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_GUIDE_TICKET_GuideRideId",
                table: "GUIDE_TICKET",
                column: "GuideRideId");

            migrationBuilder.CreateIndex(
                name: "IX_MODEL_BrandId",
                table: "MODEL",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ROUTE_FromCityId",
                table: "ROUTE",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_ROUTE_ToCityId",
                table: "ROUTE",
                column: "ToCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TOURIST_ApplicationUserId",
                table: "TOURIST",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TOURIST_CountryId",
                table: "TOURIST",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CAR_PHOTO");

            migrationBuilder.DropTable(
                name: "DRIVER_LANGUAGE");

            migrationBuilder.DropTable(
                name: "DRIVER_RATING");

            migrationBuilder.DropTable(
                name: "DRIVER_RIDE_TO_ROUTE");

            migrationBuilder.DropTable(
                name: "DRIVER_ROUTE");

            migrationBuilder.DropTable(
                name: "DRIVER_TICKET");

            migrationBuilder.DropTable(
                name: "GUIDE_LANGUAGE");

            migrationBuilder.DropTable(
                name: "GUIDE_RATING");

            migrationBuilder.DropTable(
                name: "GUIDE_RIDE_TO_ROUTE");

            migrationBuilder.DropTable(
                name: "GUIDE_ROUTE");

            migrationBuilder.DropTable(
                name: "GUIDE_TICKET");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DRIVER_RIDE");

            migrationBuilder.DropTable(
                name: "LANGUAGE");

            migrationBuilder.DropTable(
                name: "FROM_TO_DATE");

            migrationBuilder.DropTable(
                name: "ROUTE");

            migrationBuilder.DropTable(
                name: "GUIDE_RIDE");

            migrationBuilder.DropTable(
                name: "DRIVER");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "GUIDE");

            migrationBuilder.DropTable(
                name: "TOURIST");

            migrationBuilder.DropTable(
                name: "CAR");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "COUNTRY");

            migrationBuilder.DropTable(
                name: "MODEL");

            migrationBuilder.DropTable(
                name: "BRAND");
        }
    }
}
