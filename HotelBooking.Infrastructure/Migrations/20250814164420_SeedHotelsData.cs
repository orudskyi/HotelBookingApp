using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedHotelsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name", "Rating", "Address_City", "Address_Country", "Address_PostalCode", "Address_Street" },
                values: new object[,]
                {
                    { 1, "Grand Hyatt", 5, "Kyiv", "Ukraine", "01001", "Khreshchatyk St, 22" },
                    { 2, "Radisson Blu", 4, "Lviv", "Ukraine", "79008", "Halytska Square, 7" },
                    { 3, "Hilton", 5, "Odesa", "Ukraine", "65009", "Frantsuzkyi Blvd, 52" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
