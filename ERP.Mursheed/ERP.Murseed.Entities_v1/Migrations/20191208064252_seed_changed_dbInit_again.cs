using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Mursheed.ORM.Migrations
{
    public partial class seed_changed_dbInit_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Lenkeran");

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[] { 2, 1, "Passat" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1,
                column: "Info",
                value: "Baki-Sumqayit d1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 2,
                column: "Info",
                value: "Baki-Gence d1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 3,
                column: "Info",
                value: "Baki-Quba d1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 4,
                column: "Info",
                value: "Baki-Qusar d1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 5,
                column: "Info",
                value: "Baki-Seki d1");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 2, "Sumqayit-Xacmaz d1" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 2, "Sumqayit-Mingecevir d1" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 2, "Sumqayit-Lenkeran d1" });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "FromCityId", "Info", "Price", "ToCityId" },
                values: new object[,]
                {
                    { 9, 1, "Baki-Sumqayit d2", 55f, 2 },
                    { 10, 1, "Baki-Gence d2", 45f, 3 },
                    { 11, 1, "Baki-Quba d2", 50f, 4 },
                    { 12, 1, "Baki-Qusar d2", 55f, 5 }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "ModelId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Transporter",
                columns: new[] { "Id", "CarId", "CountryId", "CustomId", "DriverLicense", "FatherName", "Firstname", "GovernmentalId", "Lastname", "Photo", "Status" },
                values: new object[] { 2, 2, 1, null, null, "Agalar", "Aga", 678912345, "Dayi", null, false });

            migrationBuilder.InsertData(
                table: "TransporterRoute",
                columns: new[] { "Id", "RouteId", "TransporterId" },
                values: new object[,]
                {
                    { 9, 9, 2 },
                    { 10, 10, 2 },
                    { 11, 11, 2 },
                    { 12, 12, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransporterRoute",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TransporterRoute",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TransporterRoute",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TransporterRoute",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Transporter",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Xacmaz");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1,
                column: "Info",
                value: "Baki");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 2,
                column: "Info",
                value: "Sumqayit");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 3,
                column: "Info",
                value: "Gence");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 4,
                column: "Info",
                value: "Quba");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 5,
                column: "Info",
                value: "Qusar");

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 1, "Seki" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 1, "Xacmaz" });

            migrationBuilder.UpdateData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FromCityId", "Info" },
                values: new object[] { 1, "Mingecevir" });
        }
    }
}
