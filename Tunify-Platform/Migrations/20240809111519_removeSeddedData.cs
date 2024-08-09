using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class removeSeddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumns: new[] { "PlaylistId", "SongId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumns: new[] { "PlaylistId", "SongId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumns: new[] { "PlaylistId", "SongId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "AlbumName", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Album 1", new DateTime(2024, 8, 8, 16, 37, 25, 613, DateTimeKind.Local).AddTicks(296) },
                    { 2, "Album 2", new DateTime(2024, 8, 8, 16, 37, 25, 613, DateTimeKind.Local).AddTicks(298) }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "This is a bio", "Artist 1" },
                    { 2, "This is a bio", "Artist 2" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "Price", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 0.00m, "Free" },
                    { 2, 9.99m, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "ArtistId", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 0, 3, 45, 0), "Pop", "Song 1" },
                    { 2, 2, 2, new TimeSpan(0, 0, 4, 20, 0), "Rock", "Song 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Join_Date", "SubscriptionId", "Username" },
                values: new object[,]
                {
                    { 1, "john@example.com", new DateTime(2024, 8, 8, 16, 37, 25, 613, DateTimeKind.Local).AddTicks(251), 1, "john_doe" },
                    { 2, "jane@example.com", new DateTime(2024, 8, 8, 16, 37, 25, 613, DateTimeKind.Local).AddTicks(267), 2, "jane_doe" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistId", "CreatedDate", "PlaylistName", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playlist 1", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Playlist 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "PlaylistSongs",
                columns: new[] { "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });
        }
    }
}
