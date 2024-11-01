using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.RenameTable(
                name: "HotelRooms",
                newName: "Hotels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedBy",
                value: new DateTime(2024, 11, 1, 19, 26, 47, 260, DateTimeKind.Local).AddTicks(4982));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "HotelRooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedBy",
                value: new DateTime(2024, 11, 1, 19, 24, 35, 863, DateTimeKind.Local).AddTicks(3660));
        }
    }
}
