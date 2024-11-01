using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateroomsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beds",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "Beds",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HotelRooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Occupancy",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "HotelRooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 101 },
                columns: new[] { "Beds", "ImageUrl", "Name", "Occupancy", "Price" },
                values: new object[] { 2, "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg", "Standard Room", 2, 90.0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 102 },
                columns: new[] { "Beds", "ImageUrl", "Name", "Occupancy", "Price" },
                values: new object[] { 2, "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg", "Standard Room", 2, 90.0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 2, 101 },
                columns: new[] { "Beds", "ImageUrl", "Name", "Occupancy", "Price" },
                values: new object[] { 2, "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg", "Standard Room", 2, 90.0 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 2, 102 },
                columns: new[] { "Beds", "ImageUrl", "Name", "Occupancy", "Price" },
                values: new object[] { 2, "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg", "Standard Room", 2, 90.0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedBy",
                value: new DateTime(2024, 11, 1, 21, 46, 40, 874, DateTimeKind.Local).AddTicks(3683));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beds",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "Beds",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Occupancy",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Beds", "Occupancy", "Price", "UpdatedBy" },
                values: new object[] { 2, 2, 90.0, new DateTime(2024, 11, 1, 20, 0, 39, 985, DateTimeKind.Local).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Beds", "Occupancy", "Price" },
                values: new object[] { 2, 2, 90.0 });
        }
    }
}
