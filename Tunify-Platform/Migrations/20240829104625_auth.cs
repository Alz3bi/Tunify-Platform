using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 29, 13, 46, 25, 568, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 29, 13, 46, 25, 568, DateTimeKind.Local).AddTicks(8749));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 29, 13, 46, 25, 568, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 29, 13, 46, 25, 568, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "35f1bf8b-47da-44e7-a333-90bd27c2d098" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "35f1bf8b-47da-44e7-a333-90bd27c2d098" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 22, 15, 31, 22, 172, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2024, 8, 22, 15, 31, 22, 172, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 15, 31, 22, 172, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 15, 31, 22, 172, DateTimeKind.Local).AddTicks(7621));
        }
    }
}
