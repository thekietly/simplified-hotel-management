using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hotelRooms",
                table: "hotelRooms");

            migrationBuilder.RenameTable(
                name: "hotelRooms",
                newName: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "hotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotelRooms",
                table: "hotelRooms",
                column: "Id");
        }
    }
}
