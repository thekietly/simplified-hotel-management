using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addData4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "HotelRooms");

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedBy",
                value: new DateTime(2024, 10, 29, 21, 27, 17, 300, DateTimeKind.Local).AddTicks(5792));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PhoneNumber", "UpdatedBy" },
                values: new object[] { "123-456-7890", new DateTime(2024, 10, 29, 21, 26, 38, 569, DateTimeKind.Local).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhoneNumber",
                value: "123-456-7890");
        }
    }
}
